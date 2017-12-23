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

            //ПФ_ПорталДПОPortTypeClient soap = new ПФ_ПорталДПОPortTypeClient(ПФ_ПорталДПОPortTypeClient.EndpointConfiguration.ПФ_ПорталДПОSoap);

            //var query = soap.ПолучитьИзмененныеДанныеОПрограммахДПОЗаПериодAsync( new DateTime(2006,1,1), DateTime.Today).Result;
            //var tertert = query.@return;


            //var werwe = new DataManager1C().Users.GetList();



            var rrrrr = new ProgramFacade();

            Console.WriteLine("Cfnt");

            var count = rrrrr.Update();

            Console.WriteLine("Cfnt");

            count.Wait();
        }



    }


}