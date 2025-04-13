namespace FitnessTrackerApi.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDatabaseConnection(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}