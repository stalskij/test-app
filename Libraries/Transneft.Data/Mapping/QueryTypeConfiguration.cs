using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transneft.Data.Mapping
{
    /// <summary>
    /// Представляет базовую конфигурацию сопоставления типов запросов
    /// </summary>
    /// <typeparam name="TQuery">Тип типа запроса</typeparam>
    public class QueryTypeConfiguration<TQuery> : IMappingConfiguration, IQueryTypeConfiguration<TQuery> where TQuery : class
    {
        #region Utilities

        /// <summary>
        /// Разработчики могут переопределить этот метод в пользовательских частичных классах для добавления некоторого пользовательского кода конфигурации
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки запроса</param>
        protected virtual void PostConfigure(QueryTypeBuilder<TQuery> builder)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Настройка типа запроса
        /// </summary>
        /// <param name="builder">Конструктор, используемый для настройки типа запроса</param>
        public virtual void Configure(QueryTypeBuilder<TQuery> builder)
        {
            //добавление пользовательской конфигурации
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
