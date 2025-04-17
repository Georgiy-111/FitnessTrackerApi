using FitnessTrackerApi.Service;
using FitnessTrackerApi.Repositories;
using FitnessTrackerApi.Data;
using Microsoft.EntityFrameworkCore;
using FitnessTrackerApi.Repositories.Interfaces;
using FitnessTrackerApi.Service.Interfaces;
using FitnessTrackerApi.Services;
using FitnessTrackerApi.Services.Interfaces;

namespace FitnessTrackerApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IWorkoutService, WorkoutService>();
            services.AddScoped<IWorkoutTypeService, WorkoutTypeService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IWorkoutTypeRepository, WorkoutTypeRepository>();
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