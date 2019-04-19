using System;

namespace Transneft.Core.Domain.PowerMeasurementPoints
{
    /// <summary>
    /// Счетчик электрической энергии
    /// </summary>
    public class ElectricityMeter: BaseEntity
    {
        /// <summary>
        /// Возвращает или задает номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Возвращает или задает тип
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Возвращает или задает дату проверки
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Возвращает или задает точку измерения электроэнергии
        /// </summary>
        public virtual PowerMeasurementPoint PowerMeasurementPoint { get; set; }
    }
}
