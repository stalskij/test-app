using Autofac;
using Microsoft.EntityFrameworkCore;
using Transneft.Api.Controllers;
using Transneft.Core.Configuration;
using Transneft.Core.Data;
using Transneft.Core.Infrastructure;
using Transneft.Core.Infrastructure.DependencyManagement;
using Transneft.Data;
using Transneft.Services.Companies;
using Transneft.Services.ConsumptionObjects;
using Transneft.Services.PowerMeasurementPoints;

namespace Transneft.Api.Infrastructure
{
    /// <summary>
    /// Регистратор зависимостей
    /// </summary>
    public class DependencyRegistrar: IDependencyRegistrar
    {
        /// <summary>
        /// Регистрация служб и интерфейсов
        /// </summary>
        /// <param name="builder">Конструктор контейнера</param>
        /// <param name="typeFinder">Тип файндера</param>
        /// <param name="config">Конфигурация</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, Config config)
        {
        }

        public void Register(ContainerBuilder builder)
        {
            //file provider
            builder.RegisterType<EngineFileProvider>().As<IEngineFileProvider>().InstancePerLifetimeScope();

            //репозитории
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            //сервисы
            builder.RegisterType<CompanyService>().As<ICompanyService>().InstancePerLifetimeScope();
            builder.RegisterType<ConsumptionObjectService>().As<IConsumptionObjectService>().InstancePerLifetimeScope();
            builder.RegisterType<PowerPointsService>().As<IPowerPointsService>().InstancePerLifetimeScope();

            //контекст БД
            builder.Register(context => new ApplicationDbContext(context.Resolve<DbContextOptions<ApplicationDbContext>>()))
                .As<IDbContext>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Возвращает порядок реализации регистратора зависимостей
        /// </summary>
        public int Order
        {
            get { return 2; }
        }
        
    }
}
