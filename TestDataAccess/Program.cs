using SaM.BusinessLogic.AdminFacade;
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


            try
            {
                //var rddd = Ddd().Result;

                var mmmm = new AdminFacade();
                mmmm.UpdateCategory();

            }
            catch ( Exception e) {
                Console.WriteLine(e);
            }
            

            XDocument xdoc = XDocument.Load("testData.xml");

            //var ttt = xdoc.Element(@"return");
            var sss = xdoc.Element("Envelope");

            //foreach (XElement phoneElement in xdoc.Element("return").Elements("ProgramEdu"))
            //{
            //    XAttribute nameAttribute = phoneElement.Attribute("XML_ID");
            //    XElement companyElement = phoneElement.Element("name");
            //    XElement priceElement = phoneElement.Element("typeProgram");

            //    if (nameAttribute != null && companyElement != null && priceElement != null)
            //    {
            //        Console.WriteLine("Смартфон: {0}", nameAttribute.Value);
            //        Console.WriteLine("Компания: {0}", companyElement.Value);
            //        Console.WriteLine("Цена: {0}", priceElement.Value);
            //    }
            //}

            //return collection;


            // Mapster
            //Assembly assem = typeof(Config1CtoDTO).GetTypeInfo().Assembly;
            //TypeAdapterConfig.GlobalSettings.Scan(assem);

            //var mmm = new Category { Id = 123, Guid = Guid.NewGuid(), Title = "OOOOOOOOOOOOOO" };
            //var pop = mmm.Adapt<CategoryDTO>();
            //pop.Id = 45;

            //mmm = pop.Adapt<CategoryDTO, Category>(mmm);
            // -----------------------------


            // Automapper

            //IMapper mapper = AutoMapperConfiguration.CreateMappings();

            //var ttt = new DataManager();
            //var mmm = new Category { Id=123, Guid = Guid.NewGuid(), Title = "OOOOOOOOOOOOOO" };
            //var sss = ttt.datamanager1C.Categories.GetList().FirstOrDefault();
            //var ooo = mapper.Map<ГруппаПрограммыОбучения, CategoryDTO>(sss);
            ////ooo.Id = 555;
            //var sdf = mapper.Map<CategoryDTO, Category>(ooo, mmm);
            //------------------------------------




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