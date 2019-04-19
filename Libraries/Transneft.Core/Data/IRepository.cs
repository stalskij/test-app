using System.Collections.Generic;
using System.Linq;

namespace Transneft.Core.Data
{
    /// <summary>
    /// Представляет репозиторий сущностей
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности</typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Methods

        /// <summary>
        /// Получить объект по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Объект</returns>
        TEntity GetById(object id);

        /// <summary>
        /// Вставить объект
        /// </summary>
        /// <param name="entity">Объект</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Вставить объекты
        /// </summary>
        /// <param name="entities">Объекты</param>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// Изменить объект
        /// </summary>
        /// <param name="entity">Объект</param>
        void Update(TEntity entity);

        /// <summary>
        /// Изменить объекты
        /// </summary>
        /// <param name="entities">Объекты</param>
        void Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// Удалить объект
        /// </summary>
        /// <param name="entity">Объект</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Удалить объекты
        /// </summary>
        /// <param name="entities">Объекты</param>
        void Delete(IEnumerable<TEntity> entities);

        #endregion

        #region Properties

        /// <summary>
        /// Получает таблицу
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Возвращает таблицу с включенным "без отслеживания" (функция EF), используйте ее только при загрузке записей только для операций только для чтения
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }

        #endregion
    }
}
