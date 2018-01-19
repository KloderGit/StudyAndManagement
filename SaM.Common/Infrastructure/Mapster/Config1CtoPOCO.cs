using Mapster;
using SaM.Common.ServiceEntity;
using SoapService1full;

namespace SaM.Common.Infrastructure.Mapster
{
    public class Config1CtoPOCO : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ГруппаПрограммыОбучения, CategoryService>()
                .Map(d => d.Guid, s => s.ГУИД)
                .Map(d => d.Title, s => s.Наименование);

            config.NewConfig<category, CategoryService>()
                .Map(dest => dest.Guid, src => src.GUID)
                .Map(dest => dest.Title, src => src.Name);


            config.NewConfig<formControl, CertificationService>()
                .Map(dest => dest.Guid, src => src.GUIDFormControl)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<ФормаКонтроля, CertificationService>()
                .Map(dest => dest.Guid, src => src.ГУИД)
                .Map(dest => dest.Title, src => src.Наименование);


            config.NewConfig<ViewAttestation, CertificationTypeService>()
                .Map(dest => dest.Guid, src => src.GUIDViewAttestation)
                .Map(dest => dest.Title, src => src.Name);


            config.NewConfig<ProgramEdu, EducationProgramService>()
                .Map(dest => dest.Guid, src => src.XML_ID)
                .Map(dest => dest.Title, src => src.name)
                .Map(dest => dest.Active, src => src.active == "Активный" ? true : false)
                .Map(dest => dest.AcceptDate, src => src.acceptDate)
                .Map(dest => dest.ProgramType, src => src.typeProgram)
                .Map(dest => dest.Category, src => src.category.Adapt<CategoryService>())
                .Map(dest => dest.EducationType, src => src.formEducation.Adapt<EducationTypeService>())
                .Map(dest => dest.StudyType, src => src.viewProgram);


            config.NewConfig<formEdu, EducationTypeService>()
                .Map(dest => dest.Guid, src => src.GUIDFormEducation)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<ФормаОбучения, EducationTypeService>()
                .Map(dest => dest.Guid, src => src.ГУИД)
                .Map(dest => dest.Title, src => src.Наименование);


            config.NewConfig<Дисциплина, SubjectService>()
                .Map(dest => dest.Guid, src => src.ГУИД)
                .Map(dest => dest.Title, src => src.Наименование);
        }
    }
}
