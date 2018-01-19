using Mapster;
using SaM.Common.POCO;
using SaM.Common.ServiceEntity;
using SaM.Domain.Core.Education;

namespace SaM.Common.Infrastructure.Mapster
{
    public class ConfigPOCOtoEntity : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<CategoryService, Category>();

            config.NewConfig<CertificationService, Certification>();

            config.NewConfig<CertificationTypeService, CertificationType>();

            config.NewConfig<EducationProgramService, EducationProgram>();

            config.NewConfig<EducationTypeService, EducationType>();

            config.NewConfig<SubjectService, Subject>();

            //config.NewConfig<EducationalPlan, EducationalPlanPOCO>()
            //        .PreserveReference(true);

            //config.NewConfig<EducationProgram, EducationProgramPOCO>()
            //    .PreserveReference(true);
        }
    }
}
