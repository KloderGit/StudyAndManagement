using AutoMapper;
using SaM.Common.DTO;
using SaM.Domain.Core.Education;
using SoapService1C;
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
            CreateMap<CategoryDTO, Category>()
                .ForMember(de => de.Guid, sr => sr.MapFrom(s => s.Guid))
                .ForMember(de => de.Title, sr => sr.MapFrom(s => s.Title));


            CreateMap<ГруппаПрограммыОбучения, CategoryDTO>()
                .ForMember(fld => fld.Guid, src => src.MapFrom(sr => sr.ГУИД))
                .ForMember(fld => fld.Title, src => src.MapFrom(sr => sr.Наименование));
        }
    }
}
