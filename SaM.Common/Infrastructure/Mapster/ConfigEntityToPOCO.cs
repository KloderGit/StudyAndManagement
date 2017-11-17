using Mapster;
using SaM.Common.POCO;
using SaM.Domain.Core.Education;

namespace SaM.Common.Infrastructure.Mapster
{
    public class ConfigEntityToPOCO : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<EducationalPlan, EducationalPlanPOCO>()
                    .PreserveReference(true);

            config.NewConfig<EducationalPlanPOCO, EducationalPlan>().Ignore(ss => ss.Id);

            config.NewConfig<Subject, SubjectPOCO>();
            config.NewConfig<SubjectPOCO, Subject>().Ignore(ss => ss.Id);

            config.NewConfig<EducationProgram, EducationProgramPOCO>()
                .PreserveReference(true);

            config.NewConfig<EducationProgramPOCO, EducationProgram>()
                .Ignore(c => c.Category)
                .Ignore(et => et.EducationType)
                .Ignore(it => it.Id);

            config.NewConfig<Category, CategoryPOCO>();
            config.NewConfig<CategoryPOCO, Category>().Ignore(ss => ss.Id);

            config.NewConfig<EducationType, EducationTypePOCO>();
            config.NewConfig<EducationTypePOCO, EducationType>().Ignore(ss => ss.Id);


            config.NewConfig<CertificationPOCO, Certification>()
                .Ignore(it => it.Id);

            config.NewConfig<CertificationType, CertificationTypePOCO>();
            config.NewConfig<CertificationTypePOCO, CertificationType>()
                .Ignore(it => it.Id);
        }
    }
}
