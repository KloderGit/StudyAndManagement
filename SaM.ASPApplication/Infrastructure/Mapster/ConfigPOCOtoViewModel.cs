using Mapster;
using SaM.ASPApplication.ViewModels;
using SaM.Common.POCO;
using System;
using System.Collections.Generic;
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

            config.NewConfig<EducationProgramPOCO, EducationProgramViewModel>();
            config.NewConfig<EducationProgramViewModel, EducationProgramPOCO>().Ignore(ss => ss.Id);
        }
    }
}
