using AutoMapper;
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
            //Assembly assem = typeof(Config1CtoDTO).GetTypeInfo().Assembly;
            //TypeAdapterConfig.GlobalSettings.Scan(assem);

            IMapper mapper = AutoMapperConfiguration.CreateMappings();

            var ttt = new DataManager();

            var mmm = new Category { Id=123, Guid = Guid.NewGuid(), Title = "OOOOOOOOOOOOOO" };
            var sss = ttt.datamanager1C.Categories.GetList().FirstOrDefault();
            var ooo = mapper.Map<ГруппаПрограммыОбучения, CategoryDTO>(sss);
            mmm = mapper.Map<CategoryDTO, Category>(ooo);


            //var pop = mmm.Adapt<CategoryDTO>();
            //pop.Id = 45;

            //mmm = pop.Adapt<Category>();



            Console.ReadLine();
        }
    }

}