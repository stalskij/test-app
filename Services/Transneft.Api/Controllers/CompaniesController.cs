using Microsoft.AspNetCore.Mvc;
using Transneft.Services.Companies;
using Transneft.Api.Framework.Controllers;

namespace Transneft.Api.Controllers
{
    /// <summary>
    /// Контроллер точки измерения
    /// </summary>
    [Route("api/[controller]")]
    public class CompaniesController : BaseController
    {
        #region Fields

        private readonly ICompanyService _companyService;

        #endregion

        #region Ctor

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        #endregion
        
        /// <summary>
        /// Возвращает список организаций
        /// </summary>
        /// <returns>Список головных организаций</returns>
        [HttpGet]
        public object Get()
        {
            var data = _companyService.GetCompaniesAll();
            return Json(data);
        }
        
        /// <summary>
        /// Возвращает организацию по ИД
        /// </summary>
        /// <param name="companyId">ИД организации</param>
        /// <returns>Организация</returns>
        [HttpGet("{companyId}")]
        public object Get(int companyId)
        {
            return _companyService.GetCompanyById(companyId);
        }
    }
}
