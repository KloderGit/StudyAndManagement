using SaM.BusinessLogic.POCO;
using SaM.Services.Repository1C;
using SoapService1C;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaM.Services
{
    public class Provider1C
    {
        public async Task<List<CategoryPOCO>> GetCategory()
        {
            var array = new List<CategoryPOCO>();

            var client = new ПФ_ПорталДПОPortTypeClient(ПФ_ПорталДПОPortTypeClient.EndpointConfiguration.ПФ_ПорталДПОSoap);
            var ttt = await client.ПолучитьГруппыПрограммОбученияAsync();

            foreach (var item in ttt.@return)
            {
                array.Add( new CategoryPOCO { Guid = new Guid(item.ГУИД), Title = item.Наименование } );
            }

            return array;
        }

        public List<CategoryPOCO> GetCategory1()
        {
            var array = new List<CategoryPOCO>();

            IDataManager1C mmm = new DataManager1C();

            var res = mmm.Categories.GetAll();

            foreach (var item in res)
            {
                array.Add(new CategoryPOCO { Guid = new Guid(item.ГУИД), Title = item.Наименование });
            }

            return array;
        }
    }
}
