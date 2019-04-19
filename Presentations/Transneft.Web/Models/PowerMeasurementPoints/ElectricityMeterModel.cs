using System;
using Transneft.Web.Framework.Models;

namespace Transneft.Core.Domain.PowerMeasurementPoints
{
    /// <summary>
    /// Модель счетчика электрической энергии
    /// </summary>
    public class ElectricityMeterModel: ModelBase
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
        public PowerMeasurementPointModel PowerMeasurementPoint { get; set; }
    }
}
