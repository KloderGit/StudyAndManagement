
using SaM.BusinessLogic.Facades.Education;
using SaM.BusinessLogic;
using SaM.Common.ServiceEntity;
using SaM.Domain.Core;
using SaM.Domain.Core.Education;
using System;


namespace TestDataAccess
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            new SaM.Common.Infrastructure.Mapster.RegisterMapsterConfig();


            var upd = new Education().Update().Result;

                        //var rrrrr = new CategoryFacade();

            //Console.WriteLine("Cfnt");

            //var count = rrrrr.Update();

            //Console.WriteLine("Cfnt");

            //count.Wait();
        }



    }


}