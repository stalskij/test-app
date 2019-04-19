using Microsoft.AspNetCore.Mvc;
using System;
using Transneft.Api.Framework.Controllers;
using Transneft.Services.PowerMeasurementPoints;

namespace Transneft.Api.Controllers
{
    /// <summary>
    /// Контроллер точки измерения
    /// </summary>
    [Route("api/[controller]")]
    public class ElectricityMetersController : BaseController
    {
        #region Fields

        private readonly IPowerPointsService _pointService;

        #endregion

        #region Ctor

        public ElectricityMetersController(IPowerPointsService pointService)
        {
            _pointService = pointService;
        }

        #endregion

        /// <summary>
        /// Возвращает список счетчиков электрической энергии с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список счетчиков электрической энергии</returns>
        [HttpGet]
        public object Get()
        {
            var data = _pointService.GetVTransformersOverdue();
            return Json(data);
        }
    }
}
