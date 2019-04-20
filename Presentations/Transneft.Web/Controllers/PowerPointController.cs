using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Transneft.Core.Domain.PowerMeasurementPoints;
using Transneft.Web.Managers;
using Transneft.Web.Models;
using Transneft.Web.ViewModels;

namespace Transneft.Web.Controllers
{
    /// <summary>
    /// Контроллер точки измерения
    /// </summary>
    public class PowerPointController : Controller
    {
        #region Fields

        private IApiManager _api;

        #endregion

        #region Ctor

        public PowerPointController()
        {
            _api = ApiManager.Instance;
        }

        #endregion

        #region Methods

        public IActionResult Overdue()
        {
            var ctData = _api.GetCTransformersOverdue();
            var vtData = _api.GetVTransformersOverdue();
            var emData = _api.GetElectricsOverdue();

            var model = new OverdueViewModel()
            {
                CurrentTransformers = ctData,
                VoltageTransformers = vtData,
                ElectricityMeters = emData
            };

            return View(model);
        }

        [HttpPost]
        public object Create(PowerMeasurementPointModel point)
        {
            _api.CreatePowerPoint(point);

            return Json("Данные успешно сохранены!");
        }
        
        #endregion
    }
}
