using System;
using Transneft.Core.Domain.ConsumptionObjects;

namespace Transneft.Core.Domain.PowerMeasurementPoints
{
    /// <summary>
    /// Точка измерения электроэнергии
    /// </summary>
    public class PowerMeasurementPoint: BaseEntity
    {
        /// <summary>
        /// Возвращает или задает наименование объекта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор объекта потребления
        /// </summary>
        public int ConsumptionObjectId { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор трансформатора напряжения
        /// </summary>
        public int VoltageTransformerId { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор трансформатора тока
        /// </summary>
        public int CurrentTransformerId { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор счетчика электрической энергии
        /// </summary>
        public int ElectricityMeterId { get; set; }

        /// <summary>
        /// Возвращает или задает объект потребления
        /// </summary>
        public virtual ConsumptionObject ConsumptionObject { get; set; }

        /// <summary>
        /// Возвращает или задает трансформатор напряжения
        /// </summary>
        public virtual VoltageTransformer VoltageTransformer { get; set; }

        /// <summary>
        /// Возвращает или задает трансформатор тока
        /// </summary>
        public virtual CurrentTransformer CurrentTransformer { get; set; }

        /// <summary>
        /// Возвращает или задает счетчик электрической энергии
        /// </summary>
        public virtual ElectricityMeter ElectricityMeter { get; set; }

    }
}
