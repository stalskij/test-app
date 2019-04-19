using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Transneft.Core.Data;
using Transneft.Core.Domain.PowerMeasurementPoints;

namespace Transneft.Services.PowerMeasurementPoints
{
    /// <summary>
    /// Сервис точек измерения электроэнергии
    /// </summary>
    public class PowerPointsService: IPowerPointsService
    {
        #region Fields

        private readonly IRepository<PowerMeasurementPoint> _pointRepository;
        private readonly IRepository<CurrentTransformer> _currentRepository;
        private readonly IRepository<VoltageTransformer> _voltageRepository;
        private readonly IRepository<ElectricityMeter> _electricityRepository;

        #endregion

        #region Ctor

        public PowerPointsService(IRepository<PowerMeasurementPoint> pointRepository,
            IRepository<CurrentTransformer> currentRepository,
            IRepository<VoltageTransformer> voltageRepository,
            IRepository<ElectricityMeter> electricityRepository)
        {
            _pointRepository = pointRepository;
            _currentRepository = currentRepository;
            _voltageRepository = voltageRepository;
            _electricityRepository = electricityRepository;
        }

        #endregion

        #region Methods

        #region Power measurement points

        /// <summary>
        /// Получить точку измерения электроэнергии по идентификатору
        /// </summary>
        /// <param name="powerMeasurementPointId">Идентификатор точки измерения электроэнергии</param>
        /// <returns>Точка измерения электроэнергии</returns>
        public virtual PowerMeasurementPoint GetPointById(int powerMeasurementPointId)
        {
            if (powerMeasurementPointId == 0)
                return null;

            return _pointRepository.GetById(powerMeasurementPointId);
        }

        /// <summary>
        /// Получить список точек измерения электроэнергии объекта потребления
        /// </summary>
        /// <param name="сonsumptionObjectId">Идентификатор объекта потребления</param>
        /// <returns>Список точек измерения электроэнергии</returns>
        public virtual IList<PowerMeasurementPoint> GetPointByConsumptionId(int сonsumptionObjectId)
        {
            if (сonsumptionObjectId == 0)
                return new List<PowerMeasurementPoint>();

            return _pointRepository.Table
                .Where(t => t.ConsumptionObjectId == сonsumptionObjectId)
                .ToList();
        }

        /// <summary>
        /// Добавить новую точку измерения
        /// </summary>
        /// <param name="point">Точка измерения</param>
        public virtual void InsertPoint(PowerMeasurementPoint point)
        {
            if(point == null)
                throw new ArgumentNullException(nameof(point));

            _pointRepository.Insert(point);
        }

        #endregion

        #region Current Transformers

        /// <summary>
        /// Получить список трансформаторов тока с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список трансформаторов тока</returns>
        public virtual IList<CurrentTransformer> GetCTransformersOverdue()
        {
            return _currentRepository.Table
                .Where(t => t.Date < DateTime.Now)
                .ToList();
        }

        #endregion

        #region Voltage Transformers
        /// <summary>
        /// Получить список трансформаторов напряжения с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список трансформаторов напряжения</returns>
        public virtual IList<VoltageTransformer> GetVTransformersOverdue()
        {
            return _voltageRepository.Table
                .Where(t => t.Date < DateTime.Now)
                .ToList();
        }

        #endregion

        #region Electricity Meters

        /// <summary>
        /// Получить список счетчиков электрической энергии с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список счетчиков электрической энергии</returns>
        public virtual IList<ElectricityMeter> GetElectricsOverdue()
        {
            return _electricityRepository.Table
                .Where(t => t.Date < DateTime.Now)
                .ToList();
        }

        #endregion

        #endregion
    }
}
