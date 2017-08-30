using AutoMapper;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Core.Education;

namespace SaM.Common.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryPOCO>();
        }
    }
}
