using Mapster;
using SaM.Domain.Core.Education;
using SoapService1full;
using SaM.Services.Repository1C;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaM.DataBases.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SaM.Common.POCO;
using SaM.BusinessLogic.AdminFacade;
using System.Linq;
using System;
using SaM.Domain.Core.User;
using System.Globalization;
using System.Threading;
using System.Reflection;
using SaM.BusinessLogic;
using SaM.Domain.Core;

namespace TestDataAccess
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            new SaM.Common.Infrastructure.Mapster.RegisterMapsterConfig();


            //var properties = typeof(EducationProgram).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //foreach (var property in properties)
            //{
            //    if (property.GetAccessors()[0].IsVirtual && !property.GetAccessors()[0].IsFinal)
            //    {
            //        Console.WriteLine(property.Name + " -  Yes");
            //    }
            //}



            //var c1 = new Category();
            //var c2 = new Category();

            //c1.Title = "asdasd";
            //c2.Title = "asdasd";

            //var sdfsdf = c1.Equals(c2);
            //var dfsf = c1.EqualService(c2);


            //var cntx = new ApplicationContext();
            //var serv = new DataManager1C();

            //var dbItems = cntx.Categories;
            //var servItems = serv.Categories.GetList().Adapt<IEnumerable<Category>>();


            //var tttt = servItems.Intersect(dbItems, new GuidComparer());


            var rrrrr = new CertificationFacade();

            Console.WriteLine("Cfnt");

            var count = rrrrr.Update();

            Console.WriteLine("Cfnt");

            count.Wait();
        }
        


    }


}