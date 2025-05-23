using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace FitnessTrackerApi.Extensions;

public static class ValidationServiceCollectionExtensions
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}