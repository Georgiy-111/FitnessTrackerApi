using FitnessTrackerApi.Service;
using FitnessTrackerApi.Repositories;

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
    }
}