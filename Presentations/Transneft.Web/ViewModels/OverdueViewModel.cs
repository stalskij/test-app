using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transneft.Core.Domain.PowerMeasurementPoints;

namespace Transneft.Web.ViewModels
{
    /// <summary>
    /// Модель представления страницы с закончившейся датой проверки
    /// </summary>
    public class OverdueViewModel
    {
        /// <summary>
        /// Возвращает список трансформаторов тока
        /// </summary>
        public IList<CurrentTransformerModel> CurrentTransformers { get; set; }

        /// <summary>
        /// Возвращает список трансформаторов напряжения
        /// </summary>
        public IList<VoltageTransformerModel> VoltageTransformers { get; set; }

        /// <summary>
        /// Возвращает список счетчиков электрической энергии
        /// </summary>
        public IList<ElectricityMeterModel> ElectricityMeters { get; set; }

        /// <summary>
        /// Активная вкладка на странице
        /// </summary>
        public ActiveTab ActiveTab { get; set; }
    }

    /// <summary>
    /// Перечисление вкладок на странице
    /// </summary>
    public enum ActiveTab
    {
        CurrentTransformer,
        VoltageTransformers,
        ElectricityMeters
    }
}
