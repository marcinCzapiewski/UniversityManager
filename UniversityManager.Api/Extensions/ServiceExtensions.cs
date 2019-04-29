using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityManager.Infrastructure.EF;

namespace UniversityManager.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<UniversityManagerContext>(options => options.UseSqlServer(config.GetConnectionString("SqlServer")));
        }
    }
}
