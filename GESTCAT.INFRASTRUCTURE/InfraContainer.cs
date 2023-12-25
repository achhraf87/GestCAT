using GESTCAT.APPLICATION.Contracts;
using GESTCAT.INFRASTRUCTURE.DATA;
using GESTCAT.INFRASTRUCTURE.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTCAT.INFRASTRUCTURE
{
    public static class InfraContainer
    {
        public static IServiceCollection AddInfraContainer(this IServiceCollection services, IConfiguration config)
        {
            
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(
                config.GetConnectionString("CATALOG_CON")));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICatalogueRepository), typeof(CatalogueRepository));
            return services;
        }
    }
}
