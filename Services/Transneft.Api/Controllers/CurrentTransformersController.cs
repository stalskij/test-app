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
    public class CurrentTransformersController : BaseController
    {
        #region Fields

        private readonly IPowerPointsService _pointService;

        #endregion

        #region Ctor

        public CurrentTransformersController(IPowerPointsService pointService)
        {
            _pointService = pointService;
        }

        #endregion

        /// <summary>
        /// Возвращает список трансформаторов тока с закончившимся сроком проверки
        /// </summary>
        /// <returns>Список трансформаторов тока</returns>
        [HttpGet]
        public object Get()
        {
            var data = _pointService.GetCTransformersOverdue();
            return Json(data);
        }
    }
}
