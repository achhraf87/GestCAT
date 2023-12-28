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


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfraContainer(builder.Configuration);
builder.Services.AddApplicationContainer();
builder.Services.AddHttpClient();
builder.Services.AddHealthChecks()
    .AddCheck<ApiHealthCheck>(nameof(ApiHealthCheck))
    .AddDbContextCheck<AppDBContext>();

builder.Services.AddScoped<ICatalogueRepository, CatalogueRepository>();
builder.Services.AddScoped<ILivreRepository, LivreRepository>();
builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));


//builder.Services.AddMassTransit(x =>
//{
//    x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));

//    x.AddRider(rider =>
//    {
//        rider.AddConsumer<KafkaMessageConsumer>();

//        rider.UsingKafka((context, k) =>
//        {
//            k.Host("localhost:9092");

//            k.TopicEndpoint<KafkaMessage>("topic-name", "consumer-group-name", e =>
//            {
//                e.ConfigureConsumer<KafkaMessageConsumer>(context);
//            });
//        });
//    });
//});

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

app.UseRouting();

app.MapHealthChecks("/healthcheck", new()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI(options => options.UIPath = "/dashboard");


app.Run();

//class KafkaMessageConsumer :
//        IConsumer<KafkaMessage>
//{
//    public Task Consume(ConsumeContext<KafkaMessage> context)
//    {
//        return Task.CompletedTask;
//    }
//}

//public record KafkaMessage
//{
//    public string Text { get; init; }
//}