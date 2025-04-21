namespace FitnessTrackerApi.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string GetDatabaseConnection(this IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Строка подключения не найдена в конфигурации.");
            }
            
            return connectionString;
        }
    }
}