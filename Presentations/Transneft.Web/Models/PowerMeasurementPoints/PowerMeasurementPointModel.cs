using System;
using Transneft.Web.Models.ConsumptionObjects;
using Transneft.Web.Framework.Models;

namespace Transneft.Core.Domain.PowerMeasurementPoints
{
    /// <summary>
    /// Модель точки измерения электроэнергии
    /// </summary>
    public class PowerMeasurementPointModel: ModelBase
    {
        public PowerMeasurementPointModel()
        {
            VoltageTransformer = new VoltageTransformerModel();
            CurrentTransformer = new CurrentTransformerModel();
            ElectricityMeter = new ElectricityMeterModel();
        }

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
        public ConsumptionObjectModel ConsumptionObject { get; set; }

        /// <summary>
        /// Возвращает или задает трансформатор напряжения
        /// </summary>
        public VoltageTransformerModel VoltageTransformer { get; set; }

        /// <summary>
        /// Возвращает или задает трансформатор тока
        /// </summary>
        public CurrentTransformerModel CurrentTransformer { get; set; }

        /// <summary>
        /// Возвращает или задает счетчик электрической энергии
        /// </summary>
        public ElectricityMeterModel ElectricityMeter { get; set; }
    }
}
