using Microsoft.EntityFrameworkCore;
using FitnessTrackerApi.Data;

namespace FitnessTrackerApi.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetDatabaseConnection()));
            return services;
        }
    }
}