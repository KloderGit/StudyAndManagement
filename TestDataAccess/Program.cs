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
            sw.Start();
            Console.Write("Query to Service - ");

            var ddddd = dssdd.EducationPrograms.GetList(new DateTime(2017, 9, 20), DateTime.Today);

            sw.Stop();
            Console.WriteLine((sw.ElapsedMilliseconds / 100.0).ToString());

            sw.Reset();
            sw.Start();
            Console.Write("Make Attestation Tree - ");

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

            sw.Stop();
            Console.WriteLine((sw.ElapsedMilliseconds / 100.0).ToString());


            var attBuild = new AttestationBuilder(attest);
            var Attdirec = new AttestationDirector(attBuild);

            Attdirec.Build();

            var attRes = attBuild.GetResult();



            var tr = database.Certifications.GetList().Where( uu => uu.Guid.ToString() == "f4190a1a-4cdc-11e6-a716-c8600054f636");


            //var attKey = attest.Select(it => it.Certification.Guid.ToString() + it.CertificationType.Guid.ToString());

            //var databsItems = database.Attestations.GetList()
            //                    .Where( db => attKey.Contains( db.Certification.Guid.ToString() + db.CertificationType.Guid.ToString() ) );

            //var dbKeys = databsItems.Select( it => it.Certification.Guid.ToString() + it.CertificationType.Guid.ToString());


            //var dsdsd = attKey.Except(dbKeys);




            var categ = ddddd.Select(pr => pr.category)
                .Where(s => String.IsNullOrEmpty(s.GUID) == false)
                                .GroupBy(x => x.GUID)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .Select(zx => zx.Value)
                                .Adapt<IEnumerable<CategoryDTO>>();


            var eduType = ddddd.Select(pr => pr.formEducation)
                .Where(s => String.IsNullOrEmpty(s.GUIDFormEducation) == false)
                                .GroupBy(x => x.GUIDFormEducation)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .Select(zx => zx.Value)
                                .Adapt<IEnumerable<EducationTypeDTO>>();


            var disc = ddddd.SelectMany(p => p.listOfSubjects)
                            .Where(f => String.IsNullOrEmpty(f.GUIDsubject) == false)
                                .GroupBy(x => x.GUIDsubject)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .Select(zx => zx.Value)
                                .Adapt<IEnumerable<SubjectDTO>>();


            var ucplan = ddddd.SelectMany(r => r.listOfSubjects
                                                .Select(s => new EducationalPlanDTO
                                                {
                                                    EducationProgram = r.Adapt<EducationProgramDTO>(),
                                                    Subject = s.Adapt<SubjectDTO>(),
                                                    Certification = String.IsNullOrEmpty(s.Attestation.formControl.GUIDFormControl) == false ?
                                                                                         s.Attestation.formControl.Adapt<CertificationDTO>() : null,
                                                    Duration = s.duration.ParseIgnoreException()
                                                })
                                         );
            var i = 0;
            foreach (var item in ucplan.Where(d => d.Duration != null && d.Duration > 0))
            {
                i++;
                Console.WriteLine(i);
                Console.WriteLine(item.Duration.ToString());
            }

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