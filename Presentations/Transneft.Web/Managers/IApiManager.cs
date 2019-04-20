using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transneft.Core.Domain.PowerMeasurementPoints;
using Transneft.Web.Models.ConsumptionObjects;

namespace Transneft.Web.Managers
{
    /// <summary>
    /// Менеджер взаимодействия с API v1
    /// </summary>
    public interface IApiManager
    {
        /// <summary>
        /// Возвращает список трансформаторов тока с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список трансформаторов тока</returns>
        IList<CurrentTransformerModel> GetCTransformersOverdue();

        /// <summary>
        /// Возвращает список трансформаторов напряжения с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список трансформаторов напряжения</returns>
        IList<VoltageTransformerModel> GetVTransformersOverdue();

        /// <summary>
        /// Возвращает список счетчиков электрической энергии с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список счетчиков электрической энергии</returns>
        IList<ElectricityMeterModel> GetElectricsOverdue();

        /// <summary>
        /// Возвращает список счетчиков электрической энергии с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список счетчиков электрической энергии</returns>
        IList<ConsumptionObjectModel> GetConsumptionObjectsAll();

        /// <summary>
        /// Создать новую точку измерения
        /// </summary>
        void CreatePowerPoint(PowerMeasurementPointModel point);
    }
}
