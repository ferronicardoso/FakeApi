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
using AutoMapper;

namespace FakeApi.WebApp.Controllers
{
    [RoutePrefix("dashboard")]
    public class DashboardController : BaseController
    {
        private List<SelectListItem> GetVerbList(VerbType? selected = null)
        {
            var result = Enum.GetValues(typeof(VerbType))
                             .Cast<VerbType>()
                            .Select(s => new SelectListItem()
                            {
                                Text = s.GetDescription(),
                                Value = s.GetDescription(),
                                Selected = selected.HasValue && selected.Value == s
                            })
                            .ToList();
            return result;
        }

        private List<SelectListItem> GetResponseStatusList(ResponseStatusType? selected = null)
        {
            var result = Enum.GetValues(typeof(ResponseStatusType))
                             .Cast<ResponseStatusType>()
                            .Select(s => new SelectListItem()
                            {
                                Text = string.Format("{0} - {1}", (int)s, s.GetDescription()),
                                Value = ((int)s).ToString(),
                                Selected = selected.HasValue && selected.Value == s
                            })
                            .ToList();
            return result;
        }

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
                                          Verb = x.Verb,
                                          ResponseStatus = string.Format("{0} - {1}", x.ResponseStatus, ((ResponseStatusType)x.ResponseStatus).GetDescription())
                                      });

                return View(model);
            }
        }

        public ActionResult Create()
        {
            ViewBag.ResponseStatusList = GetResponseStatusList();
            ViewBag.VerbList = GetVerbList();
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
                ViewBag.ResponseStatusList = GetResponseStatusList((ResponseStatusType)model.ResponseStatus);
                ViewBag.VerbList = GetVerbList((VerbType)Enum.Parse(typeof(VerbType), model.Verb));
                return View(model.To<RestMockEditDto>());
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