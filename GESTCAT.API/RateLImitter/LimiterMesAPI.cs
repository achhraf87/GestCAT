using System.Threading.RateLimiting;

namespace GESTCAT.API.RateLImitter
{
    public static class LimiterMesAPI
    {
        public static void LimitterMesApi(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(content =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: content.Request.Headers.Host.ToString(),
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = 5,
                            QueueLimit = 0,
                            Window = TimeSpan.FromSeconds(10)
                        })
                );

                options.RejectionStatusCode = 429;
            });
        }
    }
}
