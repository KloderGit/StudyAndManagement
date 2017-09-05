using Mapster;
using SaM.Common.DTO;
using SoapService1C;

namespace SaM.Common.Infrastructure.Mapster
{
    public class Config1CtoDTO : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ГруппаПрограммыОбучения, CategoryDTO>()                
                .Map(d => d.Guid, s => s.ГУИД)
                .Map(d => d.Title, s => s.Наименование);

            config.NewConfig<ФормаКонтроля, CertificationDTO>()
                .Map( dest => dest.Guid, src => src.ГУИД )
                .Map( dest => dest.Title, src => src.Наименование );

            config.NewConfig<ФормаОбучения, EducationTypeDTO>()
                .Map(dest => dest.Guid, src => src.ГУИД)
                .Map(dest => dest.Title, src => src.Наименование);
        }
    }
}
