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



            var rrrrr = new CategoryFacade();

            Console.WriteLine("Cfnt");

            var count = rrrrr.Update();

            Console.WriteLine("Cfnt");

            count.Wait();
        }
        


    }


}