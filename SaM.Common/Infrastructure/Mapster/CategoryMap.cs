using AutoMapper;
using SaM.Common.DTO;
using SaM.Domain.Core.Education;
using SoapService1full;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.Infrastructure.Mapster
{
    public class CategoryMap : Profile
    {
        public CategoryMap()
        {
            CreateMap<Category, CategoryDTO>();
            //CreateMap<CategoryDTO, Category>().ForSourceMember(ss => ss.Id, ee => ee.Ignore());
            CreateMap<CategoryDTO, Category>().ForMember(ss => ss.Id, ee => ee.Ignore());



            CreateMap<ГруппаПрограммыОбучения, CategoryDTO>()
                .ForMember(fld => fld.Guid, src => src.MapFrom(sr => sr.ГУИД))
                .ForMember(fld => fld.Title, src => src.MapFrom(sr => sr.Наименование));
        }
    }
}
