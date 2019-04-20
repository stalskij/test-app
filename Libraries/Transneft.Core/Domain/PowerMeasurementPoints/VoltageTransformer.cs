using System;

namespace Transneft.Core.Domain.PowerMeasurementPoints
{
    /// <summary>
    /// Трансформатор напряжения
    /// </summary>
    public class VoltageTransformer: BaseEntity
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
        /// Возвращает или задает коэффициент трансформации
        /// </summary>
        public decimal Ktn { get; set; }
        
        /// <summary>
        /// Возвращает или задает точку измерения электроэнергии
        /// </summary>
        public virtual PowerMeasurementPoint PowerMeasurementPoint { get; set; }
    }
}
