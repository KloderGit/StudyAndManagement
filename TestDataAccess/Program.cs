using SaM.DataBases.EntityFramework;
using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;
using SaM.Services;
using SoapService1C;
using System;
using System.Threading.Tasks;

namespace TestDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkEF();
            //DisplayResultAsync();
            Console.ReadLine();
        }


        static void WorkEF() {
            IDataManager datamanager = new DataManagerEntityFramework();

            var cat = datamanager.Categories.GetAll();

            var nnn = new Category { Guid = Guid.NewGuid(), Title = "The first category - Test Entity access" };

            datamanager.Categories.Add(nnn);
            datamanager.Save();

            foreach (var item in cat)
            {
                Console.WriteLine(item.Guid.ToString() + " | " + item.Title);
            }

        }


        static async void DisplayResultAsync()
        {
            var client = await new Provider1C().GetCategory();

            foreach (var item in client)
            {
                Console.WriteLine( item.Guid.ToString() + " | " + item.Title );
            }

            Console.ReadKey();
        }
    }
}