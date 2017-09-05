using Mapster;
using SaM.BusinessLogic.DAL;
using SaM.BusinessLogic.Pages.UpdateEntity;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;
using System;
using System.Reflection;

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assem = typeof(SaM.Common.Infrastructure.Mapster.Config1CtoDTO).GetTypeInfo().Assembly;

            TypeAdapterConfig.GlobalSettings.Scan(assem);

            //WorkEF();
            DisplayResultAsync();
            Console.ReadLine();
        }


        static void WorkEF() {
            IDataManager datamanager = new DataManagerEntityFramework();

            var cat = datamanager.Categories.GetAll();

            var nnn = new Category { Guid = Guid.NewGuid(), Title = "The first category - Test Entity access" };

            datamanager.Categories.Add(nnn);
            datamanager.Save();

            foreach (var item in cat)
            {
                Console.WriteLine(item.Guid.ToString() + " | " + item.Title);
            }

        }


        static void DisplayResultAsync()
        {

            var rrr = new UpdateEntity();

            var ttt = rrr.GetCategories();

            var mmm = rrr.GetCertifications();

            var sss = rrr.GetEducationTypes();

            var ddddd = new DataManagerFromEF().GetCategories();

            Console.ReadKey();
        }
    }
}