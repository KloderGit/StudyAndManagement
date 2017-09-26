using SaM.BusinessLogic.AdminFacade;
using SaM.BusinessLogic.AdminFacade.UpdateEntity;
using SaM.Common.DTO;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using SoapService1full;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {

            var sfsf = new AdminFacade();
                sfsf.UpdateCategory();


            Console.ReadLine();
        }


        public static async Task<bool> Ddd() {

            ПФ_ПорталДПОPortTypeClient soap = new ПФ_ПорталДПОPortTypeClient(ПФ_ПорталДПОPortTypeClient.EndpointConfiguration.ПФ_ПорталДПОSoap);

            //var query = await soap.ПолучитьДанныеОФЛAsync("7fd968c1-0b18-11e7-80f1-0cc47a4b75cc");    // Работает

            //var query = await soap.ПолучитьИзмененныеДанныеОФЛЗаПериодAsync(DateTime.Today, DateTime.Today);

            //var query = await soap.ПолучитьВидыПрограммAsync();


            var query = await soap.ПолучитьИзмененныеДанныеОПрограммахДПОЗаПериодAsync(new DateTime(2017, 9, 20), DateTime.Today);

            //var query = await soap.ПолучитьДанныеОПрограммеAsync("bc8c3a38-5289-11e7-80f3-0cc47a4b75cc");    // Работает

            //var query = await soap.ПолучитьДанныеПоАттестациямФЛAsync("7fd968c1-0b18-11e7-80f1-0cc47a4b75cc");    // Работает

            //var sdff = await soap.ПолучитьВидыПрограммAsync();

            return true;
        }
    }

}