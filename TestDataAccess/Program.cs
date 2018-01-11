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
using System.Collections;
using SaM.Common.Infrastructure;

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
            //    if (property.GetAccessors()[0].IsVirtual && !property.GetAccessors()[0].IsFinal )
            //    {
            //        Console.WriteLine(property.Name + " -  Yes" + " | " + typeof(IEnumerable).IsAssignableFrom(property.PropertyType));
            //    }
            //}



            //Console.WriteLine(" : " + sdf.GetDTO());

            //ПФ_ПорталДПОPortTypeClient soap = new ПФ_ПорталДПОPortTypeClient(ПФ_ПорталДПОPortTypeClient.EndpointConfiguration.ПФ_ПорталДПОSoap);

            //var query = soap.ПолучитьИзмененныеДанныеОПрограммахДПОЗаПериодAsync( new DateTime(2006,1,1), DateTime.Today).Result;
            //var tertert = query.@return;


            //var werwe = new DataManager1C().Users.GetList();



            var pr1 = new EducationProgram
            {
                Id = 1000,
                AcceptDate = DateTime.Today,
                Active = true,
                CategoryId = 1200,
                EducationTypeId = 1300,
                Guid = new Guid(),
                Order = 5,
                ProgramType = "UUUU",
                StudyType = "PPPPPPPPPPPPPPP",
                Title = "----------------------",
                Category = new Category { Id = 100 }
            };

            var pr2 = new EducationProgram
            {
                Id = 1000,
                AcceptDate = DateTime.Today,
                Active = true,
                CategoryId = 1200,
                EducationTypeId = 1300,
                Guid = new Guid(),
                Order = 5,
                ProgramType = "UUUU",
                StudyType = "PPPPPPPPPPPPPPP",
                Title = "----------------------",
                Category = new Category { Id = 101 }
            };


            Console.WriteLine(pr1.Equals(pr2));




            //var rrrrr = new ProgramFacade();

            //Console.WriteLine("Cfnt");

            //var count = rrrrr.UpdateFromService();

            //Console.WriteLine("Cfnt");

            //count.Wait();
        }



    }


}