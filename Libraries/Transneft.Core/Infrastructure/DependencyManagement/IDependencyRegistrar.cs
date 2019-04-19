using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Transneft.Core.Configuration;

namespace Transneft.Core.Infrastructure.DependencyManagement
{
    /// <summary>
    /// Интерфейс регистратора зависимостей
    /// </summary>
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// Регистрация служб и интерфейсов
        /// </summary>
        /// <param name="builder">Конструктор контейнера</param>
        void Register(ContainerBuilder builder);

        /// <summary>
        /// Регистрация служб и интерфейсов
        /// </summary>
        /// <param name="builder">Конструктор контейнера</param>
        /// <param name="typeFinder">Тип файндера</param>
        /// <param name="config">Конфигурация</param>
        void Register(ContainerBuilder builder, ITypeFinder typeFinder, Config config);

        /// <summary>
        /// Возвращает порядок реализации регистратора зависимостей
        /// </summary>
        int Order { get; }
    }
}
