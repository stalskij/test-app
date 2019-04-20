using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transneft.Core.Domain.PowerMeasurementPoints;
using Transneft.Web.Framework.Managers;
using Transneft.Web.Models.ConsumptionObjects;

namespace Transneft.Web.Managers
{
    /// <summary>
    /// Менеджер взаимодействия с API v1
    /// </summary>
    public class ApiManager : ManagerBase, IApiManager ////TODO: Inject
    {
        #region Fields

        private static ApiManager _instance;

        #endregion

        #region Ctor

        public ApiManager(string api) : base(api) { }

        #endregion

        #region Properties

        /// <summary>
        /// Возвращает экземпляр объекта "одиночку"
        /// </summary>
        public static ApiManager Instance
        {
            get
            {
                return _instance ?? throw new ArgumentNullException();
            }
        }

        #endregion

        #region Utilities

        public static void Create(string api)
        {
            _instance = new ApiManager(api);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Возвращает список трансформаторов тока с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список трансформаторов тока</returns>
        public IList<CurrentTransformerModel> GetCTransformersOverdue()
        {
            var data = Get<List<CurrentTransformerModel>>("currenttransformers");
            return data;
        }

        /// <summary>
        /// Возвращает список трансформаторов напряжения с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список трансформаторов напряжения</returns>
        public IList<VoltageTransformerModel> GetVTransformersOverdue()
        {
            var data = Get<List<VoltageTransformerModel>>("voltagetransformers");
            return data;
        }

        /// <summary>
        /// Возвращает список счетчиков электрической энергии с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список счетчиков электрической энергии</returns>
        public IList<ElectricityMeterModel> GetElectricsOverdue()
        {
            var data = Get<List<ElectricityMeterModel>>("electricitymeters");
            return data;
        }

        /// <summary>
        /// Возвращает список счетчиков электрической энергии с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список счетчиков электрической энергии</returns>
        public IList<ConsumptionObjectModel> GetConsumptionObjectsAll()
        {
            var data = Get<List<ConsumptionObjectModel>>("consumptionobjects");
            return data;
        }

        /// <summary>
        /// Создать новую точку измерения
        /// </summary>
        public void CreatePowerPoint(PowerMeasurementPointModel point)
        {
            Post("powerpoints", point);
        }

        #endregion
    }
}
