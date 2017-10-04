using Mapster;
using SaM.BusinessLogic.AdminFacade;
using SaM.BusinessLogic.AdminFacade.UpdateEntity;
using SaM.Common.DTO;
using SaM.Common.Infrastructure.Mapster;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using SoapService1full;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using SaM.Common.Infrastructure;
using SaM.BusinessLogic.AdminFacade.Builders;
using SaM.Common.POCO;
using SaM.DataBases.EntityFramework;
using System.Diagnostics;
using SaM.DataBases.Infrastructure;

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {

            Assembly assem = typeof(Config1CtoDTO).GetTypeInfo().Assembly;
            Assembly assem2 = typeof(Config1CtoPOCO).GetTypeInfo().Assembly;
            TypeAdapterConfig.GlobalSettings.Scan(assem, assem2);

            var dssdd = new DataManager1C();
            var database = new DataManagerEF();


            var sw = new Stopwatch();

            sw.Start(); Console.Write("Query to Service - ");
            var ddddd = dssdd.EducationPrograms.GetList(new DateTime(2017, 9, 20), DateTime.Today).Where(ac => ac.active == "Активный");
            sw.Stop(); Console.WriteLine((sw.ElapsedMilliseconds / 100.0).ToString());


            sw.Reset(); sw.Start(); Console.Write("Make Attestation Tree - ");

            var attest = ddddd.SelectMany(p => p.listOfSubjects)
                    .Select(att => att.Attestation)
                    .Where(att => String.IsNullOrEmpty(att.formControl.GUIDFormControl) == false)
                                .GroupBy(x => x.formControl.GUIDFormControl)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .SelectMany(zx => zx.Value.SpisokVariantAttestation.Select(el => new AttestationPOCO
                                {
                                    Certification = zx.Value.formControl.Adapt<CertificationPOCO>(),
                                    CertificationType = el.Adapt<CertificationTypePOCO>()
                                }));

            var attBuild = new AttestationBuilder(attest);
            var Attdirec = new AttestationDirector(attBuild);
            Attdirec.Build();

            sw.Stop(); Console.WriteLine((sw.ElapsedMilliseconds / 100.0).ToString());


            sw.Reset(); sw.Start(); Console.Write("Make EducationPlan Tree - ");

            var educationPlanTree = ddddd.SelectMany(r => r.listOfSubjects.Where(f => String.IsNullOrEmpty(f.GUIDsubject) == false)
                                   .Select(s => new EducationalPlanPOCO
                                   {
                                       EducationProgram = r.Adapt<EducationProgramPOCO>(),
                                       Subject = s.Adapt<SubjectPOCO>(),
                                       Certification = String.IsNullOrEmpty(s.Attestation.formControl.GUIDFormControl) == false ?
                                                                            s.Attestation.formControl.Adapt<CertificationPOCO>() : null,
                                       Duration = s.duration.ParseIgnoreException()
                                   })
                             );

            var eduPlanBuild = new EducationPlanBuilder(educationPlanTree);
            var eduDirector = new EducationPlanDirector(eduPlanBuild);
            eduDirector.Build();

            sw.Stop(); Console.WriteLine((sw.ElapsedMilliseconds / 100.0).ToString());

            Console.ReadLine();
        }


        static int getInt(string str)
        {
            try
            {
                if (str == null) { str = "0"; }
                return Int32.Parse(str);
            }
            catch (Exception e)
            {
                Console.WriteLine(" -- " + str + " -- ");
                return 0;
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