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

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            new SaM.Common.Infrastructure.Mapster.RegisterMapsterConfig();

            //new SaM.Common.Infrastructure.Mapster.RegisterMapsterConfig();
            //new SaM.ASPApplication.Infrastructure.Mapster.RegisterMapsterConfig();

            //var result = new AdminFacade().GetPrograms().Where( p => p.Title.Contains("Персональный"));

            //    var rrr = result.Adapt<IEnumerable<EducationProgramPOCO>, IEnumerable<ProgramViewModel>>();

            //foreach (var a in rrr)
            //{
            //    Console.WriteLine(a.Title);

            //    foreach (var item in a.SubjectList)
            //    {
            //        Console.WriteLine("----- " + item.Title + "  { " + item.Certification + " }"  );
            //    }
            //}

            //var ttt = new DataManager1C();
            //var ddd = new ApplicationContext();

            //var mmm = ttt.Users.GetList(new DateTime(2017, 10, 18), DateTime.Today);
            //var res = mmm.Adapt<IEnumerable<ДанныеПоФизЛицу>, IEnumerable<UserPOCO>>();

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item.LastName + " " + item.FirstName + " " + item.ParentMidleName  );
            //}

            //ddd.AddRange(res.Adapt<IEnumerable<UserPOCO>, IEnumerable<User>>());

            //ddd.SaveChanges();

            //ПФ_ПорталДПОPortTypeClient soap = new ПФ_ПорталДПОPortTypeClient(ПФ_ПорталДПОPortTypeClient.EndpointConfiguration.ПФ_ПорталДПОSoap);



            //var tttt = soap.ПолучитьДанныеОСлушателяхФЛAsync("e28c7922-e2fd-11e6-80ee-0cc47a4b75cc").Result;
            //var mmm = tttt.@return;

            Console.WriteLine("-----------");
            var ttttttt = Dsdsd();
            Console.WriteLine("-----------");
            ttttttt.Wait();

        }


        public static async Task<IEnumerable<ДанныеПоФизЛицу>> Dsdsd() {
            ПФ_ПорталДПОPortTypeClient soap = new ПФ_ПорталДПОPortTypeClient(ПФ_ПорталДПОPortTypeClient.EndpointConfiguration.ПФ_ПорталДПОSoap);
            var query = await soap.ПолучитьИзмененныеДанныеОФЛЗаПериодAsync(new DateTime(2017, 10, 20), DateTime.Today);

            foreach (var item in query.@return)
            {
                Console.WriteLine(item);
            }

            return query.@return;
        }

        public static async Task<IEnumerable<ДанныеОСлушателеФЛ>> Dseeee(string it)
        {
            ПФ_ПорталДПОPortTypeClient soap = new ПФ_ПорталДПОPortTypeClient(ПФ_ПорталДПОPortTypeClient.EndpointConfiguration.ПФ_ПорталДПОSoap);
            var tttt = await soap.ПолучитьДанныеОСлушателяхФЛAsync(it);
            return tttt.@return;
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

            //var query = await soap.ПолучитьПрограммыОбученияAsync();

            var query = await soap.ПолучитьИзмененныеДанныеОФЛЗаПериодAsync(new DateTime(2017, 11, 20), DateTime.Today);


            var tttt = soap.ПолучитьДанныеОСлушателяхФЛAsync("e28c7922-e2fd-11e6-80ee-0cc47a4b75cc").Result;

            var mmm = query.@return;

            return true;
        }


    }

}