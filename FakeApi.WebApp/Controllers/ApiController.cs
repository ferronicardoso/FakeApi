using FakeApi.Domain.Models;
using FakeApi.Infrastructure.Repositories;
using LiteDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeApi.WebApp.Controllers
{
    [RoutePrefix("api")]
    public class ApiController : BaseController
    {
        [HttpGet, Route("info")]
        public ActionResult Version()
        {
            var version = new { version = "1.0.0.0" };
            return Json(version, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Permalink(string permalink)
        {
            var method = this.Request.HttpMethod;
            var model = GetRestMock(permalink);
            
            var jsonResult = Content(model.ResponseBody, model.ContentType);
            return jsonResult;
        }

        private RestMock GetRestMock(string path)
        {
            using (var repository = new RestMockRepository(this.ConnectionString))
            {
                var model = repository.Get(x => x.Path == path);
                return model;
            }
        }
    }
}