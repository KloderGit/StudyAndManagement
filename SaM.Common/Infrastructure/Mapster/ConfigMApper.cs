using AutoMapper;
using SaM.Common.DTO;
using SaM.Domain.Core.Education;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.Infrastructure.Mapster
{
    public class ConfigMApper : Profile, IProfile
    {
        public ConfigMApper()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>().ForMember(x => x.Id, y => y.Ignore());
        }
    }
}