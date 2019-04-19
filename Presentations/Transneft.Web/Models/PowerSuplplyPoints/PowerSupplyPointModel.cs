using System;
using System.Collections.Generic;
using System.Text;
using Transneft.Web.Framework.Models;
using Transneft.Web.Models.ConsumptionObjects;

namespace Transneft.Core.Domain.PowerSuplplyPoints
{
    /// <summary>
    /// Точка поставки электроэнергии
    /// </summary>
    public class PowerSupplyPointModel: ModelBase
    {
        /// <summary>
        /// Возвращает или задает наименование точки поставки
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает мощность
        /// </summary>
        public decimal Power { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор объекта потребления
        /// </summary>
        public int ConsumptionObjectId { get; set; }

        /// <summary>
        /// Возвращает или задает объект потребления
        /// </summary>
        public ConsumptionObjectModel ConsumptionObject { get; set; }
    }
}
