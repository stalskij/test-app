using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transneft.Core;

namespace Transneft.Data.Mapping
{
    public class EntityTypeConfiguration<TEntity> : IMappingConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        #region Utilities

        /// <summary>
        /// Разработчики могут переопределить этот метод в пользовательских частичных классах для добавления некоторого пользовательского кода конфигурации
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки сущности</param>
        protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        ///  Настройка сущности
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки сущности</param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //добвление пользовательской конфигурации
            PostConfigure(builder);
        }

        /// <summary>
        /// Применить эту конфигурацию сопоставления
        /// </summary>
        /// <param name="modelBuilder">Конструктор, используемый для построения модели контекста базы данных</param>
        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }

        #endregion
    }
}
