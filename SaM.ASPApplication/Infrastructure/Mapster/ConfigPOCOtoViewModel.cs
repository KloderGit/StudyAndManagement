using Mapster;
using SaM.ASPApplication.Areas.Admin.ViewModels;
using SaM.Common.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaM.ASPApplication.Infrastructure.Mapster
{
    public class ConfigPOCOtoViewModel : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CertificationTypePOCO, CertificationTypeViewModel>();
            config.NewConfig<CertificationTypeViewModel, CertificationTypePOCO>().Ignore(ss => ss.Id);

            config.NewConfig<CertificationPOCO, CertificationViewModel>();
            config.NewConfig<CertificationViewModel, CertificationPOCO>().Ignore(ss => ss.Id);

            config.NewConfig<SubjectPOCO, SubjectViewModel>();
            config.NewConfig<SubjectViewModel, SubjectPOCO>().Ignore(ss => ss.Id);

            config.NewConfig<EducationTypePOCO, EducationTypeViewModel>();
            config.NewConfig<EducationTypeViewModel, EducationTypePOCO>().Ignore(ss => ss.Id);

            config.NewConfig<CategoryPOCO, CategoryViewModel>();
            config.NewConfig<CategoryViewModel, CategoryPOCO>().Ignore(ss => ss.Id);

            config.NewConfig<EducationProgramPOCO, ProgramViewModel>()
                .Map(cat => cat.Category, src => src.Category.Title ?? "")
                .Map(typ => typ.EducationType, src => src.EducationType.Title ?? "")
                .Map(sbj => sbj.SubjectList, src => src.EducationalPlanList );

            config.NewConfig<EducationalPlanPOCO, SubjectViewModel>()
                .Map(sb => sb.Certification, ds => ds.Certification != null ? ds.Certification.Title : "")
                .Map(sb => sb.Duration, ds => ds.Duration)
                .Map(sb => sb.Guid, ds => ds.Subject.Guid)
                .Map(sb => sb.Title, ds => ds.Subject.Title);

            config.NewConfig<ProgramViewModel, EducationProgramPOCO>().Ignore(ss => ss.Id);
        }
    }
}
