using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Transneft.Api.Framework.Controllers;
using Transneft.Core.Domain.PowerMeasurementPoints;
using Transneft.Services.Companies;
using Transneft.Services.PowerMeasurementPoints;

namespace Transneft.Api.Controllers
{
    /// <summary>
    /// Контроллер точки измерения
    /// </summary>
    [Route("api/[controller]")]
    public class PowerPointsController : BaseController
    {
        #region Fields

        private readonly IPowerPointsService _powerPointsService;

        #endregion

        #region Ctor

        public PowerPointsController(IPowerPointsService powerPointsService)
        {
            _powerPointsService = powerPointsService;
        }

        #endregion

        /// <summary>
        /// Возвращает список точек измерения конкретного объекта потребления
        /// </summary>
        /// <param name="objectId">ИД объекта потребления</param>
        /// <returns>Список точек измерения</returns>
        [HttpGet("{сonsumptionObjectId}")]
        public object Get(int сonsumptionObjectId)
        {
            var data = _powerPointsService.GetPointByConsumptionId(сonsumptionObjectId);
            return Json(data);
        }

        /// <summary>
        /// Сохраняет точку измерения
        /// </summary>
        /// <param name="point">Точка измерения</param>
        [HttpPost]
        public void Post([FromBody]PowerMeasurementPoint point)
        {
            _powerPointsService.InsertPoint(point);
        }
    }
}
