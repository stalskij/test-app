using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using Transneft.Core;
using Transneft.Data.Mapping;

namespace Transneft.Data
{
    /// <summary>
    /// Представляет контекст БД
    /// </summary>
    public class TransneftDbContext : DbContext, IDbContext
    {
        #region Ctor

        public TransneftDbContext(DbContextOptions<TransneftDbContext> options) : base(options)
        {
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Дальнейшая настройка модели
        /// </summary>
        /// <param name="modelBuilder">Конструктор, используемый для построения модели для данного контекста</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //динамически загружать все конфигурации сущностей и типов запросов
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                    && (type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)
                        || type.BaseType.GetGenericTypeDefinition() == typeof(QueryTypeConfiguration<>)));

            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Измените входной SQL-запрос, добавив переданные параметры
        /// </summary>
        /// <param name="sql">Сырой SQL-запрос </param>
        /// <param name="parameters">Значения, присваиваемые параметрам</param>
        /// <returns>Модифицированный сырой SQL-запрос</returns>
        protected virtual string CreateSqlWithParameters(string sql, params object[] parameters)
        {
            //добавление параметров в sql
            for (var i = 0; i <= (parameters?.Length ?? 0) - 1; i++)
            {
                if (!(parameters[i] is DbParameter parameter))
                    continue;

                sql = $"{sql}{(i > 0 ? "," : string.Empty)} @{parameter.ParameterName}";

                //будет ли выходной параметр
                if (parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Output)
                    sql = $"{sql} output";
            }

            return sql;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Создает DbSet, который можно использовать для запроса и сохранения экземпляров сущности
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <returns>Набор для данного типа сущности</returns>
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Создать сценарий для создания всех таблиц для текущей модели
        /// </summary>
        /// <returns>SQL-скрипт</returns>
        public virtual string GenerateCreateScript()
        {
            return Database.GenerateCreateScript();
        }

        /// <summary>
        /// Создает запрос LINQ для типа запроса на основе необработанного SQL-запроса
        /// </summary>
        /// <typeparam name="TQuery">Тип запроса</typeparam>
        /// <param name="sql">Сырой SQL-запрос</param>
        /// <param name="parameters">Значения, присваиваемые параметрам</param>
        /// <returns>IQueryable, представляющий необработанный SQL-запрос</returns>
        public virtual IQueryable<TQuery> QueryFromSql<TQuery>(string sql, params object[] parameters) where TQuery : class
        {
            return Query<TQuery>().FromSql(CreateSqlWithParameters(sql, parameters), parameters);
        }

        /// <summary>
        /// Создает запрос LINQ для сущности на основе необработанного SQL-запроса
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="sql">Сырой SQL-запрос</param>
        /// <param name="parameters">Значения, присваиваемые параметрам</param>
        /// <returns>IQueryable, представляющий необработанный SQL-запрос</returns>
        public virtual IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : BaseEntity
        {
            return Set<TEntity>().FromSql(CreateSqlWithParameters(sql, parameters), parameters);
        }

        /// <summary>
        /// Выполняет заданный SQL для базы данных
        /// </summary>
        /// <param name="sql">SQL для выполнения</param>
        /// <param name="doNotEnsureTransaction">правда - создание транзакций не обеспечивается; ложь - создание транзакций гарантирована.</param>
        /// <param name="timeout">Тайм-аут для команды. Обратите внимание, что тайм-аут команды отличается от тайм-аута соединения, который обычно задается в строке подключения к базе данных</param>
        /// <param name="parameters">Значения, присваиваемые параметрам</param>
        /// <returns>Количество затронутых строк</returns>
        public virtual int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            //установить определенный тайм-аут команды
            var previousTimeout = Database.GetCommandTimeout();
            Database.SetCommandTimeout(timeout);

            var result = 0;
            if (!doNotEnsureTransaction)
            {
                //использование с транзакцией
                using (var transaction = Database.BeginTransaction())
                {
                    result = Database.ExecuteSqlCommand(sql, parameters);
                    transaction.Commit();
                }
            }
            else
                result = Database.ExecuteSqlCommand(sql, parameters);

            //вернуть предыдущий тайм-аут
            Database.SetCommandTimeout(previousTimeout);

            return result;
        }

        /// <summary>
        /// Отсоединить сущность от контекста
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entity">Сущность</param>
        public virtual void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityEntry = Entry(entity);
            if (entityEntry == null)
                return;
            
            entityEntry.State = EntityState.Detached;
        }

        #endregion
    }
}
