using Mapster;
using SaM.Domain.Core.Education;
using SaM.Domain.Core.User;
using SoapService1full;
using System;
using System.Collections.Generic;

namespace SaM.Common.Infrastructure.Mapster
{
    class Config1CtoEntity : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //  Маппинг Программы обучения

            config.NewConfig<ГруппаПрограммыОбучения, Category>()
                .Map(d => d.Guid, s => s.ГУИД)
                .Map(d => d.Title, s => s.Наименование);

            config.NewConfig<category, Category>()
                .Map(dest => dest.Guid, src => src.GUID)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<Category, Category>()
                .Ignore(it => it.Id);


            config.NewConfig<formControl, Certification>()
                .Map(dest => dest.Guid, src => src.GUIDFormControl)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<ФормаКонтроля, Certification>()
                .Map(dest => dest.Guid, src => src.ГУИД)
                .Map(dest => dest.Title, src => src.Наименование);

            config.NewConfig<Certification, Certification>()
                .Ignore(it => it.Id);


            config.NewConfig<formEdu, EducationType>()
                .Map(dest => dest.Guid, src => src.GUIDFormEducation)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<ФормаОбучения, EducationType>()
                .Map(dest => dest.Guid, src => src.ГУИД)
                .Map(dest => dest.Title, src => src.Наименование);

            config.NewConfig<EducationType, EducationType>()
                .Ignore(it => it.Id);


            config.NewConfig<ViewAttestation, CertificationType>()
                .Map(dest => dest.Guid, src => src.GUIDViewAttestation)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<CertificationType, CertificationType>()
                .Ignore(it => it.Id);


            config.NewConfig<Группа, Group>()
                .Map(dest => dest.Guid, src => src.ГУИД)
                .Map(dest => dest.Title, src => src.Наименование);

            config.NewConfig<Group, Group>()
                .Ignore(it => it.Id);


            config.NewConfig<Дисциплина, Subject>()
                .Map(dest => dest.Guid, src => src.ГУИД)
                .Map(dest => dest.Title, src => src.Наименование);

            config.NewConfig<Subject, Subject>()
                .Ignore(it => it.Id);


            config.NewConfig<ProgramEdu, EducationProgram>()
                .Map(dest => dest.Guid, src => src.XML_ID)
                .Map(dest => dest.Title, src => src.name)
                .Map(dest => dest.Active, src => src.active == "Активный" ? true : false)
                .Map(dest => dest.AcceptDate, src => src.acceptDate)
                .Map(dest => dest.ProgramType, src => src.typeProgram)
                .Map(dest => dest.Category, src => src.category.Adapt<Category>())
                .Map(dest => dest.EducationType, src => src.formEducation.Adapt<EducationType>())
                .Map(dest => dest.StudyType, src => src.viewProgram);

            config.NewConfig<EducationProgram, EducationProgram>()
                .Ignore(it => it.Id);




            //   Маппинг пользователя
            config.NewConfig<ДанныеПоФизЛицу, UserProfile>()
                 .Map(dest => dest.Birthday, src => DateTime.Parse(src.birth))
                 .Map(dest => dest.Gender, src => src.sex)
                 .Map(dest => dest.Phone, src => src.phone)
                 .Map(dest => dest.Skype, src => src.skype)
                 .Map(dest => dest.WWW, src => src.website);

            config.NewConfig<ДанныеПоФизЛицу, UserPhoto>()
                  .Map(dest => dest.Url, src => src.photo);

            config.NewConfig<ДанныеПоФизЛицу, UserLocation>()
                  .Map(dest => dest.Country, src => src.citizenship)
                  .Map(dest => dest.Post, src => src.post)
                  .Map(dest => dest.City, src => src.city)
                  .Map(dest => dest.Address, src => src.adress);

            config.NewConfig<ДанныеПоКарте, UserCard>()
                 .Map(dest => dest.Number, src => src.login)
                 .Map(dest => dest.PassCode, src => src.code);

            config.NewConfig<ДанныеПоФизЛицу, User>()
                .Map(dest => dest.Guid, src => src.XML_ID)
                .Map(dest => dest.Email, src => src.email)
                .Map(dest => dest.FirstName, src => src.fName)
                .Map(dest => dest.LastName, src => src.sName)
                .Map(dest => dest.ParentMidleName, src => src.tName)
                .Map(dest => dest.Profile, src => src.Adapt<UserProfile>())
                .Map(dest => dest.Photo, src => src.Adapt<UserPhoto>())
                .Map(dest => dest.Location, src => src.Adapt<UserLocation>())
                .Map(dest => dest.Cards, src => src.cardListAll.Adapt<IEnumerable<ДанныеПоКарте>, IEnumerable<UserCard>>());

            config.NewConfig<ГруппаФЛ, Group>()
                .Map(dest => dest.Guid, src => src.GUID)
                .Map(dest => dest.Title, src => src.Name);

            config.NewConfig<ГруппаФЛ, SubGroup>()
                .Map(dest => dest.Title, src => src.SubGroup);

            config.NewConfig<ДанныеОСлушателеФЛ, UserContract>()
                .Map(dest => dest.Guid, src => src.Contract.GUID)
                .Map(dest => dest.OpenDate, src => src.Contract.DataOpen)
                .Map(dest => dest.CloseDate, src => src.Contract.DataClose)
                .Map(dest => dest.EducationStart, src => src.Group.DataStart)
                .Map(dest => dest.EducationEnd, src => src.Group.DataFinish)
                .Map(dest => dest.Pay, src => src.Contract.Price)
                .Map(dest => dest.Result, src => src.Status)
                .Map(dest => dest.StudentGUID, src => src.GUID)
                .Map(dest => dest.Group, src => src.Group.Adapt<Group>());

        }
    }
}
