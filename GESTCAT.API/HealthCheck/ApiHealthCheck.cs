using Azure;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GESTCAT.API.HealthCheck
{
    public class ApiHealthCheck : IHealthCheck
    {
        private readonly HttpClient _httpClient;
        public ApiHealthCheck(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var res = await _httpClient.GetAsync("https://localhost:5031/api/Catalog");

            if (res.IsSuccessStatusCode)
            {
                return await Task.FromResult(new HealthCheckResult(
                    status: HealthStatus.Healthy,
                    description:"Api est joinable"));
            }
            return await Task.FromResult(new HealthCheckResult(
                   status: HealthStatus.Unhealthy,
                   description: "Api n'est  pas joinable"));
        }
    }
}
