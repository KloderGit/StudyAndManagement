using Mapster;
using SaM.Common.DTO;
using SaM.Domain.Core.Education;
using SoapService1full;

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
                .Map(dest => dest.Guid, src => src.ГУИД)
                .Map(dest => dest.Title, src => src.Наименование);

            config.NewConfig<formControl, CertificationDTO>()
                .Map(dest => dest.Guid, src => src.GUIDFormControl)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<ФормаОбучения, EducationTypeDTO>()
                .Map(dest => dest.Guid, src => src.ГУИД)
                .Map(dest => dest.Title, src => src.Наименование);

            config.NewConfig<ProgramEdu, EducationProgramDTO>()
                .Map(dest => dest.Guid, src => src.XML_ID)
                .Map(dest => dest.Title, src => src.name)
                .Map(dest => dest.StudyType, src => src.viewProgram)
                .Map(desc => desc.ProgramType, src => src.typeProgram)
                .Map(desc => desc.Active, src => src.active == "Активный" ? true : false)
                .Map(desc => desc.AcceptDate, src => src.acceptDate.Date.ToString())
                .Map(desc => desc.Category, src => src.category)
                .Map(dest => dest.EducationType, src => src.formEducation);

                config.NewConfig<category, CategoryDTO>()
                    .Map(dest => dest.Guid, src => src.GUID)
                    .Map(dest => dest.Title, src => src.Name);

                config.NewConfig<formEdu, EducationTypeDTO>()
                    .Map(dest => dest.Guid, src => src.GUIDFormEducation)
                    .Map(dest => dest.Title, src => src.Name);


            config.NewConfig<subject, SubjectDTO>()
                .Map(dest => dest.Guid, src => src.GUIDsubject)
                .Map(dest => dest.Title, src => src.subjectName);

            config.NewConfig<ViewAttestation, CertificationTypeDTO>()
                .Map(dest => dest.Guid, src => src.GUIDViewAttestation)
                .Map(dest => dest.Title, src => src.Name);


            config.NewConfig<CategoryDTO, Category>().Ignore(ss => ss.Id);
            config.NewConfig<Category, CategoryDTO>();

            config.NewConfig<CertificationDTO, Certification>().Ignore(ss => ss.Id);
            config.NewConfig<Certification, CertificationDTO>();

            config.NewConfig<EducationTypeDTO, EducationType>().Ignore(ss => ss.Id);
            config.NewConfig<EducationType, EducationTypeDTO>();

        }
    }
}
