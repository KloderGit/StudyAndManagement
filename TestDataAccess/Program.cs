using AutoMapper;
using SaM.BusinessLogic.DataAccessLayer;
using SaM.Common.DTO;
using SaM.Common.Infrastructure.Mapster;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using System;
using System.Linq;
using System.Reflection;

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assembly assem = typeof(SaM.Common.Infrastructure.Mapster.Config1CtoDTO).GetTypeInfo().Assembly;

            //TypeAdapterConfig.GlobalSettings.Scan(assem);

            Mappings.RegisterMappings();

            var ttt = new DataManager();

            var eeee = ttt.datamanagerEF.Categories.GetList().FirstOrDefault();

            var mmm = Mapper.Map<Category, CategoryDTO>(eeee);

            mmm.Title = "LKJLKJSKLDJ LKJSDDSA";
            mmm.Id = 1000;

            var wwwww = ttt.datamanagerEF.Categories.GetList().FirstOrDefault();

            wwwww = Mapper.Map<CategoryDTO, Category>(mmm);

            Console.ReadLine();
        }
    }



    public class Mappings
    {
        public static void RegisterMappings()
        {
            var all =
            Assembly
               .GetEntryAssembly()
               .GetReferencedAssemblies()
               .Select(Assembly.Load)
               .SelectMany(x => x.DefinedTypes)
               .Where(type => typeof(IProfile).GetTypeInfo().IsAssignableFrom(type.AsType()));

            foreach (var ti in all)
            {
                var t = ti.AsType();
                if (t.Equals(typeof(IProfile)))
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.AddProfiles(t); // Initialise each Profile classe
                    });
                }
            }
        }

    }
}