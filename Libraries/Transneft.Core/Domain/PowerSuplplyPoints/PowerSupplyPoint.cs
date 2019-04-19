using System;
using System.Collections.Generic;
using System.Text;
using Transneft.Core.Domain.ConsumptionObjects;

namespace Transneft.Core.Domain.PowerSuplplyPoints
{
    /// <summary>
    /// Точка поставки электроэнергии
    /// </summary>
    public class PowerSupplyPoint: BaseEntity
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
        public virtual ConsumptionObject ConsumptionObject { get; set; }
    }
}
