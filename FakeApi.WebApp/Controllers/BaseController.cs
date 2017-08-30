using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeApi.WebApp.Controllers
{
    public class BaseController : Controller
    {
        public string ConnectionString
        {
            get
            {
                var dbFileName = HttpContext.Server.MapPath("~/App_Data/FakeApi.db");
                return dbFileName;
            }
        }
    }
}