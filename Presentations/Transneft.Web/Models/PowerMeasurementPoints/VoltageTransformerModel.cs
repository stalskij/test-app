using System;
using Transneft.Web.Framework.Models;

namespace Transneft.Core.Domain.PowerMeasurementPoints
{
    /// <summary>
    /// Модель трансформатора напряжения
    /// </summary>
    public class VoltageTransformerModel: ModelBase
    {
        /// <summary>
        /// Возвращает или задает номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Возвращает или задает тип
        /// </summary>
        public string Type { get; set; }

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
        public PowerMeasurementPointModel PowerMeasurementPoint { get; set; }
    }
}
