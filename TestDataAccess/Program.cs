using Mapster;
using SaM.Domain.Core.Education;
using SoapService1full;
using System.Collections.Generic;
using System.Threading.Tasks;
using SaM.DataBases.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SaM.ASPApplication.Areas.Admin.ViewModels;
using SaM.Common.POCO;
using SaM.BusinessLogic.AdminFacade;
using System.Linq;
using System;

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {

            new SaM.Common.Infrastructure.Mapster.RegisterMapsterConfig();
            new SaM.ASPApplication.Infrastructure.Mapster.RegisterMapsterConfig();

            var result = new AdminFacade().GetPrograms().Where( p => p.Title.Contains("Персональный"));

                var rrr = result.Adapt<IEnumerable<EducationProgramPOCO>, IEnumerable<ProgramViewModel>>();

            foreach (var a in rrr)
            {
                Console.WriteLine(a.Title);

                foreach (var item in a.SubjectList)
                {
                    Console.WriteLine("----- " + item.Title + "  { " + item.Certification + " }"  );
                }
            }
        }


        public static async Task<bool> Ddd()
        {

            ПФ_ПорталДПОPortTypeClient soap = new ПФ_ПорталДПОPortTypeClient(ПФ_ПорталДПОPortTypeClient.EndpointConfiguration.ПФ_ПорталДПОSoap);

            //var query = await soap.ПолучитьДанныеОФЛAsync("7fd968c1-0b18-11e7-80f1-0cc47a4b75cc");    // Работает

            //var query = await soap.ПолучитьИзмененныеДанныеОФЛЗаПериодAsync(DateTime.Today, DateTime.Today);

            //var query = await soap.ПолучитьВидыПрограммAsync();


            //var query = await soap.ПолучитьИзмененныеДанныеОПрограммахДПОЗаПериодAsync(new DateTime(2017, 9, 20), DateTime.Today);

            //var query = await soap.ПолучитьДанныеОПрограммеAsync("bc8c3a38-5289-11e7-80f3-0cc47a4b75cc");    // Работает

            //var query = await soap.ПолучитьДанныеПоАттестациямФЛAsync("7fd968c1-0b18-11e7-80f1-0cc47a4b75cc");    // Работает

            //var sdff = await soap.ПолучитьВидыПрограммAsync();

            var query = await soap.ПолучитьПрограммыОбученияAsync();



            return true;
        }


    }

}