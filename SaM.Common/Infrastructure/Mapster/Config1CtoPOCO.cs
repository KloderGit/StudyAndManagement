using Mapster;
using SaM.Common.DTO;
using SaM.Common.POCO;
using SaM.Domain.Core.User;
using SoapService1full;
using System;
using System.Collections.Generic;

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

            config.NewConfig<ViewAttestation, CertificationTypePOCO>()
                .Map(dest => dest.Guid, src => src.GUIDViewAttestation)
                .Map(dest => dest.Title, src => src.Name);


            config.NewConfig<category, CategoryPOCO>()
                .Map(dest => dest.Guid, src => src.GUID)
                .Map(dest => dest.Title, src => src.Name);


            config.NewConfig<formEdu, EducationTypePOCO>()
                .Map(dest => dest.Guid, src => src.GUIDFormEducation)
                .Map(dest => dest.Title, src => src.Name);


            config.NewConfig<ProgramEdu, EducationProgramPOCO>()
                .Map(dest => dest.Guid, src => src.XML_ID)
                .Map(dest => dest.Title, src => src.name)
                .Map(dest => dest.Active, src => src.active == "Активный" ? true : false)
                .Map(dest => dest.AcceptDate, src => src.acceptDate)
                .Map(dest => dest.ProgramType, src => src.typeProgram)
                .Map(dest => dest.Category, src => src.category.Adapt<CategoryPOCO>())
                .Map(dest => dest.EducationType, src => src.formEducation.Adapt<EducationTypePOCO>())
                .Map(dest => dest.StudyType, src => src.viewProgram);


            config.NewConfig<subject, SubjectPOCO>()
                .Map(dest => dest.Guid, src => src.GUIDsubject)
                .Map(dest => dest.Title, src => src.subjectName);


            //   Маппинг пользователя

            config.NewConfig<ДанныеПоФизЛицу, UserProfilePOCO>()
                 .Map(dest => dest.Birthday, src => DateTime.Parse(src.birth))
                 .Map(dest => dest.Gender, src => src.sex)
                 .Map(dest => dest.Phone, src => src.phone)
                 .Map(dest => dest.Skype, src => src.skype)
                 .Map(dest => dest.WWW, src => src.website);

            config.NewConfig<ДанныеПоФизЛицу, UserPhotoPOCO>()
                  .Map(dest => dest.Url, src => src.photo);

            config.NewConfig<ДанныеПоФизЛицу, UserLocationPOCO>()
                  .Map(dest => dest.Country, src => src.citizenship)
                  .Map(dest => dest.Post, src => src.post)
                  .Map(dest => dest.City, src => src.city)
                  .Map(dest => dest.Address, src => src.adress);

            config.NewConfig<ДанныеПоКарте, UserCardPOCO>()
                 .Map(dest => dest.Number, src => src.login)
                 .Map(dest => dest.PassCode, src => src.code);

            config.NewConfig<ДанныеПоФизЛицу, UserPOCO>()
                .Map(dest => dest.Guid, src => src.XML_ID)
                .Map(dest => dest.Email, src => src.email)
                .Map(dest => dest.FirstName, src => src.fName)
                .Map(dest => dest.LastName, src => src.sName)
                .Map(dest => dest.ParentMidleName, src => src.tName)
                .Map(dest => dest.Profile, src => src.Adapt<UserProfilePOCO>())
                .Map(dest => dest.Photo, src => src.Adapt<UserPhotoPOCO>())
                .Map(dest => dest.Location, src => src.Adapt<UserLocationPOCO>())
                .Map(dest => dest.Cards, src => src.cardListAll.Adapt<IEnumerable<ДанныеПоКарте>, IEnumerable<UserCardPOCO>>());

            config.NewConfig<UserPOCO, User>()
                .Ignore(it => it.Id);
        }
    }
}
