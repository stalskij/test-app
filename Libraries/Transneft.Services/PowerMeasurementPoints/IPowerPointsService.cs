using System;
using System.Collections.Generic;
using System.Text;
using Transneft.Core.Domain.PowerMeasurementPoints;

namespace Transneft.Services.PowerMeasurementPoints
{
    /// <summary>
    /// Сервис точек измерения электроэнергии
    /// </summary>
    public interface IPowerPointsService
    {
        #region Power measurement points

        /// <summary>
        /// Получить точку измерения электроэнергии по идентификатору
        /// </summary>
        /// <param name="powerMeasurementPointId">Идентификатор точки измерения электроэнергии</param>
        /// <returns>Точка измерения электроэнергии</returns>
        PowerMeasurementPoint GetPointById(int powerMeasurementPointId);

        /// <summary>
        /// Получить список точек измерения электроэнергии объекта потребления
        /// </summary>
        /// <param name="сonsumptionObjectId">Идентификатор объекта потребления</param>
        /// <returns>Список точек измерения электроэнергии</returns>
        IList<PowerMeasurementPoint> GetPointByConsumptionId(int сonsumptionObjectId);

        /// <summary>
        /// Добавить новую точку измерения
        /// </summary>
        /// <param name="powerMeasurementPoint">Точка измерения</param>
        void InsertPoint(PowerMeasurementPoint powerMeasurementPoint);

        #endregion

        #region Current Transformers

        /// <summary>
        /// Получить список трансформаторов тока с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список трансформаторов тока</returns>
        IList<CurrentTransformer> GetCTransformersOverdue();

        #endregion


        #region Voltage Transformers
        /// <summary>
        /// Получить список трансформаторов напряжения с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список трансформаторов напряжения</returns>
        IList<VoltageTransformer> GetVTransformersOverdue();

        #endregion

        #region Electricity Meters

        /// <summary>
        /// Получить список счетчиков электрической энергии с закончившимся сроком проверки
        /// </summary>
        /// <param name="date">Дата проверки</param>
        /// <returns>Список счетчиков электрической энергии</returns>
        IList<ElectricityMeter> GetElectricsOverdue(); 

        #endregion
    }
}
