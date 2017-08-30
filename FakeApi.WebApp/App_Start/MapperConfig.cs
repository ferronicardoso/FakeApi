using AutoMapper;
using FakeApi.WebApp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeApi.WebApp.App_Start
{
    public static class MapperConfig
    {
        public static void InitMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ViewModelMapProfile>();
            });
        }
    }
}