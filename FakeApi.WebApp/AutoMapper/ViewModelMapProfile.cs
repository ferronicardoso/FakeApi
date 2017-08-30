using AutoMapper;
using FakeApi.Domain.Dtos;
using FakeApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeApi.WebApp.AutoMapper
{
    public class ViewModelMapProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DtoMapperProfile";
            }
        }

        public ViewModelMapProfile()
        {
            CreateMap<RestMock, RestMockEditDto>();
        }
    }
}