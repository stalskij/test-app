using System;
using System.Collections.Generic;
using System.Text;
using Transneft.Core.Domain.ConsumptionObjects;

namespace Transneft.Services.ConsumptionObjects
{
    /// <summary>
    /// Сервис объектов потребления
    /// </summary>
    public interface IConsumptionObjectService
    {
        #region ConsumptionObjects

        /// <summary>
        /// Возвращает список объектов потребления
        /// </summary>
        /// <returns>Список объектов потребления</returns>
        IList<ConsumptionObject> GetConsumptionObjectsAll();

        /// <summary>
        /// Получить объект потребления по идентификатору
        /// </summary>
        /// <param name="сonsumptionObjectId">Идентификатор объекта потребления</param>
        /// <returns>Объект потреблени</returns>
        ConsumptionObject GetConsumptionObjectById(int сonsumptionObjectId);

        /// <summary>
        /// Получить список объектов потребления дочерней организации 
        /// </summary>
        /// <param name="affiliatedCompanyId">Идентификатор дочерней организации</param>
        /// <returns>Список объектов потребления</returns>
        IList<ConsumptionObject> GetConsumptionObjectsByAffiliatedId(int affiliatedCompanyId);

        #endregion

    }
}
