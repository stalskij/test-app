using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transneft.Core.Configuration;

namespace Transneft.Api.Infrastructure
{
    /// <summary>
    /// Классы, реализующие этот интерфейс, могут служить порталом для различных служб.
    /// Редактирование функциональности, модулей и реализаций, доступ к большинству функций ведется через этот интерфейс.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Получить IServiceProvider
        /// </summary>
        /// <returns>IServiceProvider</returns>
        IServiceProvider GetServiceProvider();

        /// <summary>
        /// Регистрация зависимостей
        /// </summary>
        /// <param name="services">Коллекция дескрипторов служб</param>
        /// <param name="typeFinder">Искатель типов</param>
        IServiceProvider ConfigureServices(IServiceCollection services);

        /// <summary>
        /// Разрешить зависимость
        /// </summary>
        /// <typeparam name="T">Тип зависимости</typeparam>
        /// <returns>Разрешенная служба</returns>
        T Resolve<T>() where T : class;

        /// <summary>
        /// Разрешить зависимость
        /// </summary>
        /// <param name="type">Тип зависимости</param>
        /// <returns>Разрешенная служба</returns>
        object Resolve(Type type);

        /// <summary>
        /// Разрешить зависимость
        /// </summary>
        /// <typeparam name="T">Тип зависимости</typeparam>
        /// <returns>Коллекция разрешенных служб</returns>
        IEnumerable<T> ResolveAll<T>();
    }
}
