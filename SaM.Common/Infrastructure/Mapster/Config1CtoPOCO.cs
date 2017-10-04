using Mapster;
using SaM.Common.DTO;
using SaM.Common.POCO;
using SaM.Domain.Core.Education;
using SoapService1full;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.Infrastructure.Mapster
{
    public class Config1CtoPOCO : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<formControl, CertificationPOCO>()
                .Map(dest => dest.Guid, src => src.GUIDFormControl)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<CertificationDTO, CertificationPOCO>()
                .Ignore(it => it.Id);

            config.NewConfig<CertificationPOCO, Certification>()
                .Ignore( it => it.Id);


            config.NewConfig<ViewAttestation, CertificationTypePOCO>()
                .Map(dest => dest.Guid, src => src.GUIDViewAttestation)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<CertificationTypePOCO, CertificationType>()
                .Ignore(it => it.Id);


            config.NewConfig<category, CategoryPOCO>()
                .Map(dest => dest.Guid, src => src.GUID)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<CategoryPOCO, Category>()
                .Ignore(it => it.Id);

            config.NewConfig<formEdu, EducationTypePOCO>()
                .Map(dest => dest.Guid, src => src.GUIDFormEducation)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<EducationTypePOCO, EducationType>()
                .Ignore(it => it.Id);


            config.NewConfig<ProgramEdu, EducationProgramPOCO>()
                .Map(dest => dest.Guid, src => src.XML_ID)
                .Map(dest => dest.Title, src => src.name)
                .Map(dest => dest.Active, src => src.active == "Активный" ? true : false)
                .Map(dest => dest.AcceptDate, src => src.acceptDate)
                .Map(dest => dest.ProgramType, src => src.typeProgram)
                .Map(dest => dest.Category, src => src.category.Adapt<CategoryPOCO>())
                .Map(dest => dest.EducationType, src => src.formEducation.Adapt<EducationTypePOCO>())
                .Map(dest => dest.StudyType, src => src.viewProgram);

            config.NewConfig<EducationProgramPOCO, EducationProgram>()
                .Ignore(c => c.Category)
                .Ignore(et=>et.EducationType)
                .Ignore(it => it.Id);

            config.NewConfig<subject, SubjectPOCO>()
                .Map(dest => dest.Guid, src => src.GUIDsubject)
                .Map(dest => dest.Title, src => src.subjectName);

            config.NewConfig<SubjectPOCO, Subject>()
                .Ignore(it => it.Id);
        }
    }
}
