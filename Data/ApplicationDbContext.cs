using Microsoft.EntityFrameworkCore;
using FitnessTrackerApi.Models;

namespace FitnessTrackerApi.Data
{
    /// <summary>
    /// Контекст базы данных для приложения FitnessTrackerApi.
    /// Определяет подключение к базе данных и управляет сущностями.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Конструктор для инициализации контекста базы данных с заданными параметрами.
        /// </summary>
        /// <param name="options">Опции конфигурации контекста базы данных.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
        /// <summary>
        /// Набор данных (таблица) для хранения тренировок.
        /// </summary>
        public DbSet<Workout> Workouts { get; set; }
    }
}