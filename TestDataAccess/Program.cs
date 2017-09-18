﻿using AutoMapper;
using Mapster;
using SaM.BusinessLogic.DataAccessLayer;
using SaM.Common.DTO;
using SaM.Common.Infrastructure.Mapster;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using SoapService1C;
using System;
using System.Linq;
using System.Reflection;

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {

            // Mapster
            //Assembly assem = typeof(Config1CtoDTO).GetTypeInfo().Assembly;
            //TypeAdapterConfig.GlobalSettings.Scan(assem);

            //var mmm = new Category { Id = 123, Guid = Guid.NewGuid(), Title = "OOOOOOOOOOOOOO" };
            //var pop = mmm.Adapt<CategoryDTO>();
            //pop.Id = 45;

            //mmm = pop.Adapt<CategoryDTO, Category>(mmm);
            // -----------------------------


            // Automapper

            //IMapper mapper = AutoMapperConfiguration.CreateMappings();

            //var ttt = new DataManager();
            //var mmm = new Category { Id=123, Guid = Guid.NewGuid(), Title = "OOOOOOOOOOOOOO" };
            //var sss = ttt.datamanager1C.Categories.GetList().FirstOrDefault();
            //var ooo = mapper.Map<ГруппаПрограммыОбучения, CategoryDTO>(sss);
            ////ooo.Id = 555;
            //var sdf = mapper.Map<CategoryDTO, Category>(ooo, mmm);
            //------------------------------------




            Console.ReadLine();
        }
    }

}