using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Transneft.Core.Data;
using Transneft.Core.Domain.ConsumptionObjects;

namespace Transneft.Services.ConsumptionObjects
{
    /// <summary>
    /// Сервис объектов потребления
    /// </summary>
    public class ConsumptionObjectService: IConsumptionObjectService
    {
        #region Fields

        private readonly IRepository<ConsumptionObject> _consumptionRepository;

        #endregion

        #region Ctor

        public ConsumptionObjectService(IRepository<ConsumptionObject> consumptionRepository)
        {
            _consumptionRepository = consumptionRepository;
        }


        #endregion

        #region Methods

        #region ConsumptionObjects

        /// <summary>
        /// Получить объект потребления по идентификатору
        /// </summary>
        /// <param name="сonsumptionObjectId">Идентификатор объекта потребления</param>
        /// <returns>Объект потреблени</returns>
        public virtual ConsumptionObject GetConsumptionObjectById(int сonsumptionObjectId)
        {
            if (сonsumptionObjectId == 0)
                return null;

            return _consumptionRepository.GetById(сonsumptionObjectId);
        }

        /// <summary>
        /// Получить список объектов потребления дочерней организации 
        /// </summary>
        /// <param name="affiliatedCompanyId">Идентификатор дочерней организации</param>
        /// <returns>Список объектов потребления</returns>
        public virtual IList<ConsumptionObject> GetConsumptionObjectsByAffiliatedId(int affiliatedCompanyId)
        {
            if (affiliatedCompanyId == 0)
                return new List<ConsumptionObject>();

            return _consumptionRepository.Table
                .Where(t => t.AffiliatedCompanyId == affiliatedCompanyId)
                .ToList();
        }

        #endregion 

        #endregion

    }
}
