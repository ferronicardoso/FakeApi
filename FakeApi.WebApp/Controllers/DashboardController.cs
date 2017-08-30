using FakeApi.Domain.Dtos;
using FakeApi.Domain.Enums;
using FakeApi.Domain.Models;
using FakeApi.Infrastructure.Repositories;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeApi.WebApp.Controllers
{
    [RoutePrefix("Dashboard")]
    public class DashboardController : BaseController
    {
        private const string CONNECTION_STRING = "fakeApi.db";
        
        // GET: Default
        public ActionResult Index()
        {
            using (var repository = new RestMockRepository(this.ConnectionString))
            {
                var model = repository.List()
                                      .Select(x => new RestMockGridDto()
                                      {
                                          IdRestMock = x.IdRestMock,
                                          Active = x.Active,
                                          DisplayName = x.DisplayName,
                                          Description = x.Description,
                                          Path = x.Path,
                                          Verb = x.Verb
                                      });

                return View(model);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestMock restMock)
        {
            using (var repository = new RestMockRepository(this.ConnectionString))
            {
                repository.Add(restMock);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            using (var repository = new RestMockRepository(this.ConnectionString))
            {
                var model = repository.Get(x => x.IdRestMock == id);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(RestMock restMock)
        {
            using (var repository = new RestMockRepository(this.ConnectionString))
            {
                repository.Update(restMock);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var repository = new RestMockRepository(this.ConnectionString))
            {
                repository.Delete(x => x.IdRestMock == id);
                return RedirectToAction("Index");
            }
        }
    }
}