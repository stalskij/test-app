using Microsoft.AspNetCore.Mvc;
using Transneft.Api.Framework.Controllers;
using Transneft.Services.ConsumptionObjects;
using System.Collections.Generic;
using Transneft.Core.Domain.ConsumptionObjects;

namespace Transneft.Api.Controllers
{
    /// <summary>
    /// Контроллер объектов потребления
    /// </summary>
    [Route("api/[controller]")]
    public class ConsumptionObjectsController : BaseController
    {
        #region Fields

        private readonly IConsumptionObjectService _objectService;

        #endregion

        #region Ctor

        public ConsumptionObjectsController(IConsumptionObjectService ojectService)
        {
            _objectService = ojectService;
        }

        #endregion

        /// <summary>
        /// Возвращает список объектов потребления дочерней организации
        /// </summary>
        /// <returns>Список объектов потребления</returns>
        [HttpGet]
        public IEnumerable<ConsumptionObject> Get()
        {
            return _objectService.GetConsumptionObjectsAll();
        }

        /// <summary>
        /// Возвращает список объектов потребления дочерней организации
        /// </summary>
        /// <param name="affiliatedCompanyId">ИД дочерней организации</param>
        /// <returns>Список объектов потребления</returns>
        [HttpGet("{affiliatedCompanyId}")]
        public IEnumerable<ConsumptionObject> Get(int affiliatedCompanyId)
        {
            return _objectService.GetConsumptionObjectsByAffiliatedId(affiliatedCompanyId);
        }
    }
}
