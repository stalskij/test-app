using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Transneft.Core;

namespace Transneft.Data
{
    /// <summary>
    /// Представляет контекст DB
    /// </summary>
    public interface IDbContext
    {
        #region Methods

        /// <summary>
        /// Создает DbSet, который можно использовать для запроса и сохранения экземпляров сущности
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <returns>Набор для данного типа сущности</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        /// <summary>
        /// Сохраняет все изменения, внесенные в этом контексте, в базе данных
        /// </summary>
        /// <returns>Число записей состояния, записанных в базу данных</returns>
        int SaveChanges();

        /// <summary>
        /// Создать сценарий для создания всех таблиц для текущей модели
        /// </summary>
        /// <returns>SQL-скрипт</returns>
        string GenerateCreateScript();

        /// <summary>
        /// Создает запрос LINQ для типа запроса на основе необработанного SQL-запроса
        /// </summary>
        /// <typeparam name="TQuery">Тип запроса</typeparam>
        /// <param name="sql">Сырой SQL-запрос</param>
        /// <param name="parameters">Значения, присваиваемые параметрам</param>
        /// <returns>IQueryable, представляющий необработанный SQL-запрос</returns>
        IQueryable<TQuery> QueryFromSql<TQuery>(string sql, params object[] parameters) where TQuery : class;

        /// <summary>
        /// Создает запрос LINQ для сущности на основе необработанного SQL-запроса
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="sql">Сырой SQL-запрос</param>
        /// <param name="parameters">Значения, присваиваемые параметрам</param>
        /// <returns>IQueryable, представляющий необработанный SQL-запрос</returns>
        IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : BaseEntity;

        /// <summary>
        /// Выполняет заданный SQL для базы данных
        /// </summary>
        /// <param name="sql">SQL для выполнения</param>
        /// <param name="doNotEnsureTransaction">правда - создание транзакций не обеспечивается; ложь - создание транзакций гарантирована.</param>
        /// <param name="timeout">Тайм-аут для команды. Обратите внимание, что тайм-аут команды отличается от тайм-аута соединения, который обычно задается в строке подключения к базе данных</param>
        /// <param name="parameters">Значения, присваиваемые параметрам</param>
        /// <returns>Количество затронутых строк</returns>
        int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);

        /// <summary>
        /// Отсоединить сущность от контекста
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="entity">Сущность</param>
        void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity;

        #endregion
    }
}
