using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Transneft.Web.Models;
using RestSharp;
using Newtonsoft.Json;
using Transneft.Web.Models.Companies;
using Transneft.Web.Managers;
using Transneft.Web.ViewModels;

namespace Transneft.Web.Controllers
{
    /// <summary>
    /// Контроллер главной страницы
    /// </summary>
    public class HomeController : Controller
    {
        #region Fields

        private IApiManager _api;

        #endregion

        #region Ctor

        public HomeController()
        {
            _api = ApiManager.Instance;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            var data = _api.GetConsumptionObjectsAll();

            var model = new PowerPointCreateViewModel()
            {
                ConsumptionObjects = data
            };

            return View(model);
        } 
        #endregion

    }
}
