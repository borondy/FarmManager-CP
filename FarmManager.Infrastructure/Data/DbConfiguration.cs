using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FarmManager.Infrastructure.Data
{
    public static class DbConfiguration
    {
        public static IServiceCollection AddFarmManagerDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FarmManagerDbContext>(options =>
                options.UseSqlite(connectionString));

            return services;
        }
    }
}
