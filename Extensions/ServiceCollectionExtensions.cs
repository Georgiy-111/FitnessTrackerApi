using FitnessTrackerApi.Service;
using FitnessTrackerApi.Repositories;
using FitnessTrackerApi.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackerApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkoutService, WorkoutService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            return services;
        }
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetDatabaseConnection()));
            return services;
        }
    }
}