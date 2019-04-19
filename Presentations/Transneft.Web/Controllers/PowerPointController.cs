using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Transneft.Web.Models;

namespace Transneft.Web.Controllers
{
    public class PowerPointController : Controller
    {
        #region Ctor

        #endregion

        public PowerPointController()
        {

        }

        #region Methods

        public IActionResult Index()
        {
            return View();
        }
        
        #endregion
    }
}
