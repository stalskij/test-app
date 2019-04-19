using Microsoft.EntityFrameworkCore;

namespace Transneft.Data.Mapping
{
    /// <summary>
    /// Представляет конфигурацию сопоставления модели контекста базы данных
    /// </summary>
    public interface IMappingConfiguration
    {
        /// <summary>
        /// Применить эту конфигурацию сопоставления
        /// </summary>
        /// <param name="modelBuilder">Конструктор, используемый для построения модели контекста базы данных</param>
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
