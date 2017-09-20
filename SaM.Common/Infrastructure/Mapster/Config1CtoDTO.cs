﻿using Mapster;
using SaM.Common.DTO;
using SaM.Domain.Core.Education;
using SoapService1C;
using System;
using System.Collections.Generic;
using System.Text;

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

            config.NewConfig<ФормаОбучения, EducationTypeDTO>()
                .Map(dest => dest.Guid, src => src.ГУИД)
                .Map(dest => dest.Title, src => src.Наименование);


            config.NewConfig<CategoryDTO, Category>().Ignore(ss => ss.Id);
            config.NewConfig<Category, CategoryDTO>();

            config.NewConfig<CertificationDTO, Certification>().Ignore(ss => ss.Id);
            config.NewConfig<Certification, CertificationDTO>();

            config.NewConfig<EducationTypeDTO, EducationType>().Ignore(ss => ss.Id);
            config.NewConfig<EducationType, EducationTypeDTO>();

        }
    }
}
