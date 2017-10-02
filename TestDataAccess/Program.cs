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

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {

            Assembly assem = typeof(Config1CtoDTO).GetTypeInfo().Assembly;
            TypeAdapterConfig.GlobalSettings.Scan(assem);

            var dssdd = new DataManager1C();

            //var ddddd = dssdd.EducationPrograms.GetList(new DateTime(2017, 9, 20), DateTime.Today).Adapt<IEnumerable<EducationProgramDTO>>();

            var ddddd = dssdd.EducationPrograms.GetList(new DateTime(2006, 9, 20), DateTime.Today);

            //foreach (var item in ddddd)
            //{
            //    var listt = item.Adapt<EducationProgramDTO>();

            //    foreach (var item2 in item.listOfSubjects)
            //    {
            //        var ttt = item2.Adapt<SubjectDTO>();

            //        var att = item2.Attestation.formControl.Adapt<CertificationDTO>();

            //        foreach (var item3 in item2.Attestation.SpisokVariantAttestation)
            //        {
            //            var ooo = item3.Adapt<CertificationTypeDTO>();
            //        }
            //    }
            //}


            var categ = ddddd.Select(pr => pr.category)
                .Where(s => String.IsNullOrEmpty(s.GUID) == false)
                                .GroupBy(x => x.GUID)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .Select(zx => zx.Value)
                                .Adapt<IEnumerable<CategoryDTO>>();

            //var upd = new UpdateCategory();
            //upd.UpdateFromService(categ);


            var eduType = ddddd.Select(pr => pr.formEducation)
                .Where(s => String.IsNullOrEmpty(s.GUIDFormEducation) == false)
                                .GroupBy(x => x.GUIDFormEducation)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .Select(zx => zx.Value)
                                .Adapt<IEnumerable<EducationTypeDTO>>();

            //var upd2 = new UpdateEducationType();
            //upd2.UpdateFromService(eduType);


            var cert = ddddd.SelectMany(p => p.listOfSubjects)
                            .Select(a => a.Attestation.formControl)
                            .Where(f => String.IsNullOrEmpty(f.GUIDFormControl) == false)
                                .GroupBy(x => x.GUIDFormControl)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .Select(zx => zx.Value)
                                .Adapt<IEnumerable<CertificationDTO>>();

            //var upd1 = new UpdateCertification();
            //upd1.UpdateFromService(cert);


            var disc = ddddd.SelectMany(p => p.listOfSubjects)
                            .Where(f => String.IsNullOrEmpty(f.GUIDsubject) == false)
                                .GroupBy(x => x.GUIDsubject)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .Select(zx => zx.Value)
                                .Adapt<IEnumerable<SubjectDTO>>();


            var certTypes = ddddd.SelectMany(p => p.listOfSubjects)
                    .SelectMany(c => c.Attestation.SpisokVariantAttestation)
                    .Where(s => String.IsNullOrEmpty(s.GUIDViewAttestation) == false)
                    .GroupBy(x => x.GUIDViewAttestation)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                    .Select(zx => zx.Value)
                    .Adapt<IEnumerable<CertificationTypeDTO>>();



            //var ucplan = ddddd.SelectMany(r => r.listOfSubjects.Select( s => new { p = r.Adapt<EducationProgramDTO>(), s = s.Adapt<SubjectDTO>() }));


            //var ucplan = ddddd.SelectMany(r => r.listOfSubjects
            //                                    .Select(s => new 
            //                                    {
            //                                        EducationProgram = r.Adapt<EducationProgramDTO>(),
            //                                        Subject = s.Adapt<SubjectDTO>(),
            //                                        Certification = String.IsNullOrEmpty(s.Attestation.formControl.GUIDFormControl) == false ?
            //                                                                             s.Attestation.formControl.Adapt<CertificationDTO>() : null,
            //                                        Duration = s.duration
            //                                    }
            //                                    ).Where(d => d.Duration != null)
            //                             );

            //foreach (var item in ucplan)
            //{
            //    Console.WriteLine(item.Duration);
            //}


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
            foreach (var item in ucplan.Where( d => d.Duration != null && d.Duration > 0))
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