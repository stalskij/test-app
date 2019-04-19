using System;
using System.Collections.Generic;
using System.Text;
using Transneft.Core.Domain.PowerMeasurementPoints;
using Transneft.Core.Domain.PowerSuplplyPoints;
using Transneft.Web.Models.Companies;
using Transneft.Web.Framework.Models;

namespace Transneft.Web.Models.ConsumptionObjects
{
    /// <summary>
    /// Модель объекта потребления
    /// </summary>
    public class ConsumptionObjectModel: Framework.Models.ModelBase
    {
        public ConsumptionObjectModel()
        {
            PowerSupplyPoints = new List<PowerSupplyPointModel>();
            PowerMeasurementPoints = new List<PowerMeasurementPointModel>();
        }

        /// <summary>
        /// Возвращает или задает наименование объекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает адрес объекта
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор дочерней организации
        /// </summary>
        public int AffiliatedCompanyId { get; set; }

        /// <summary>
        /// Возвращает или задает дочернюю организацию
        /// </summary>
        public AffiliatedCompanyModel AffiliatedCompany { get; set; }

        /// <summary>
        /// Возвращает или задает список точек поствки электроэнергии
        /// </summary>
        public IList<PowerSupplyPointModel> PowerSupplyPoints { get; set; }

        /// <summary>
        /// Возвращает или задает список точек измерения
        /// </summary>
        public IList<PowerMeasurementPointModel> PowerMeasurementPoints { get; set; }
    }
}
