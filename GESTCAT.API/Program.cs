using GESTCAT.INFRASTRUCTURE;
using GESTCAT.APPLICATION;
using GESTCAT.INFRASTRUCTURE.DATA;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using GESTCAT.API.HealthCheck;
using HealthChecks.UI.Client;
using MassTransit;
using GESTCAT.API.Controllers;
using GESTCAT.APPLICATION.Contracts;
using GESTCAT.INFRASTRUCTURE.Repositories;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create.Consumers;
using GESTCAT.APPLICATION.Features.Cataloguee.Commands.Create.Events;
using System.Net;
using System.Reflection;
using GESTCAT.API;
using System.Threading.RateLimiting;
using GESTCAT.API.RateLImitter;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.LimitterMesApi();
builder.Services.AddInfraContainer(builder.Configuration);
builder.Services.AddApplicationContainer();
builder.Services.AddHttpClient();
builder.Services.AddHealthChecks()
    .AddCheck<ApiHealthCheck>(nameof(ApiHealthCheck))
    .AddDbContextCheck<AppDBContext>();

builder.Services.AddScoped<ICatalogueRepository, CatalogueRepository>();
builder.Services.AddScoped<ILivreRepository, LivreRepository>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));


builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));

    x.AddRider(rider =>
    {
        rider.AddConsumer<CatalogueCreatedEventConsumer>();

        rider.AddProducer<CatalogueDeletedEvent>(nameof(CatalogueDeletedEvent));

        rider.UsingKafka((context, k) =>
        {
            k.Host("localhost:9092");

            k.TopicEndpoint<CatalogueCreatedEvent>(nameof(CatalogueCreatedEvent), GetUniqueNames.GetUniqueName(nameof(CatalogueCreatedEvent)), e =>
            {
                // e.AutoOffsetReset = AutoOffsetReset.Latest;
                //e.ConcurrencyLimit = 3;
                e.CheckpointInterval = TimeSpan.FromSeconds(10);
                e.ConfigureConsumer<CatalogueCreatedEventConsumer>(context);

                e.CreateIfMissing(t =>
                {
                    //t.NumPartitions = 2; //number of partitions
                    //t.ReplicationFactor = 1; //number of replicas
                });
            });
        });
    });
});

//builder.Services.AddMassTransitHostedService(true);

builder.Services.
    AddHealthChecksUI(oprions =>
    {
        oprions.AddHealthCheckEndpoint("healthcheck API", "/Healthcheck");
    })
    .AddInMemoryStorage();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRateLimiter();

app.UseRouting();

app.MapHealthChecks("/healthcheck", new()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI(options => options.UIPath = "/dashboard");

app.Run();

