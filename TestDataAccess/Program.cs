using SaM.DataBases.EntityFramework;
using SaM.Services.Repository1C;
using System;
using System.Reflection;

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assembly assem = typeof(SaM.Common.Infrastructure.Mapster.Config1CtoDTO).GetTypeInfo().Assembly;

            //TypeAdapterConfig.GlobalSettings.Scan(assem);

            var sfsdf = new DataManagerEF();

            var ddd = sfsdf.Categories.GetList();

            var df = new DataManager1C();

            var kkk = df.Categories.GetList();

            //WorkEF();
            //DisplayResultAsync();
            Console.ReadLine();
        }


        //static void WorkEF() {
        //    IDataManager datamanager = new DataManagerEntityFramework();

        //    var cat = datamanager.Categories.GetAll();

        //    var nnn = new Category { Guid = Guid.NewGuid(), Title = "The first category - Test Entity access" };

        //    datamanager.Categories.Add(nnn);
        //    datamanager.Save();

        //    foreach (var item in cat)
        //    {
        //        Console.WriteLine(item.Guid.ToString() + " | " + item.Title);
        //    }

        //}


        //static void DisplayResultAsync()
        //{

        //    var rrr = new UpdateEntity();

        //    var ttt = rrr.GetCategories();

        //    var mmm = rrr.GetCertifications();

        //    var sss = rrr.GetEducationTypes();


        //    Console.ReadKey();
        //}
    }
}