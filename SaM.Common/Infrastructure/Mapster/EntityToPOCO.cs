using Mapster;
using SaM.Common.DTO;
using SaM.Common.POCO;
using SaM.Domain.Core.Education;
using SoapService1C;

namespace SaM.Common.Infrastructure.Mapster
{
    public class EntityToPOCO : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category, CategoryPOCO>();
            config.NewConfig<EducationProgram, EducationProgramPOCO>();
        }
    }
}
