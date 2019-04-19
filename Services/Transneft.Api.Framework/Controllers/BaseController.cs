using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transneft.Api.Framework.Controllers
{
    public class BaseController: Controller
    {
        #region Utilities

        public override JsonResult Json(object data)
        {
            return base.Json(data, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        } 

        #endregion
    }
}
