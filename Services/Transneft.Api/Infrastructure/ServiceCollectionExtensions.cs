using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Transneft.Data;
using Transneft.Core.Infrastructure;
using Transneft.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace Transneft.Api.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add services to the application and configure service provider
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        /// <param name="hostingEnvironment">Hosting environment</param>
        /// <returns>Configured service provider</returns>
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services,
            IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            //добавление средства доступа к HttpContext
            services.AddHttpContextAccessor();

            //добавление CORS
            services.AddCors();

            //добавление MVC
            services.AddMvc();
            
            //добавление DBContext 
            var connectionString = configuration["ConnectionStrings:Transneft"].ToString();
            services.AddDbContext<ApplicationDbContext>(t => t.UseSqlServer(connectionString));

            //создать движок и настроить поставщика услуг
            var engine = EngineContext.Create();
            var serviceProvider = engine.ConfigureServices(services);

            var sqlProvider = new SqlServerDataProvider();
            sqlProvider.InitializeDatabase();

            return serviceProvider;
        }
    }
}
