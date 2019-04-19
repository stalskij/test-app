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
    public class VoltageTransformerController : BaseController
    {
        #region Fields

        private readonly IPowerPointsService _pointService;

        #endregion

        #region Ctor

        public VoltageTransformerController(IPowerPointsService pointService)
        {
            _pointService = pointService;
        }

        #endregion

        /// <summary>
        /// Возвращает список трансформаторов напряжения с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список трансформаторов напряжения</returns>
        [HttpGet]
        public object Get()
        {
            var data = _pointService.GetVTransformersOverdue();
            return Json(data);
        }
    }
}
