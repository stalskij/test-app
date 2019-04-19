using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Transneft.Api.Infrastructure
{
    /// <summary>
    /// Представляет движок системы
    /// </summary>
    public class Engine : IEngine ////TODO: Надо весь функционал вынести в библиотеку *.Core
    {
        #region Properties

        /// <summary>
        /// Возвращает или задает IServiceProvider
        /// </summary>
        private IServiceProvider _serviceProvider { get; set; }

        #endregion

        #region Utilities

        /// <summary>
        /// Получить IServiceProvider
        /// </summary>
        /// <returns>IServiceProvider</returns>
        public IServiceProvider GetServiceProvider()
        {
            var accessor = ServiceProvider.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            return context?.RequestServices ?? ServiceProvider;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Регистрация зависимостей
        /// </summary>
        /// <param name="services">Коллекция дескрипторов служб</param>
        /// <param name="typeFinder">Искатель типов</param>
        /// <returns>Поставщик услуг</returns>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            var builder = new ContainerBuilder();

            //регистрация движка
            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            builder.Populate(services);

            //регистрация зависимостей
            var dependencyRegistrar = new DependencyRegistrar();
            dependencyRegistrar.Register(builder);

            //создать поставщика услуг 
            _serviceProvider = new AutofacServiceProvider(builder.Build());

            return _serviceProvider;
        }

        /// <summary>
        /// Разрешить зависимость
        /// </summary>
        /// <typeparam name="T">Тип зависимости</typeparam>
        /// <returns>Разрешенная служба</returns>
        public T Resolve<T>() where T : class
        {
            return (T)GetServiceProvider().GetRequiredService(typeof(T));
        }

        /// <summary>
        /// Разрешить зависимость
        /// </summary>
        /// <param name="type">Тип зависимости</param>
        /// <returns>Разрешенная служба</returns>
        public object Resolve(Type type)
        {
            return GetServiceProvider().GetRequiredService(type);
        }

        /// <summary>
        /// Разрешить зависимость
        /// </summary>
        /// <typeparam name="T">Тип зависимости</typeparam>
        /// <returns>Коллекция разрешенных служб</returns>
        public IEnumerable<T> ResolveAll<T>()
        {
            return (IEnumerable<T>)GetServiceProvider().GetServices(typeof(T));
        }
        #endregion

        #region Properties

        /// <summary>
        /// Провайдер сервиса
        /// </summary>
        public virtual IServiceProvider ServiceProvider => _serviceProvider;

        #endregion
    }
}
