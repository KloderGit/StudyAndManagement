using System;
using System.Collections.Generic;
using System.Text;
using SaM.Domain.Interfaces.Repositories;
using SoapService1C;

namespace SaM.Services.Repository1C
{
    public class DataManager1C : IDataManager1C
    {

        ПФ_ПорталДПОPortTypeClient soap;

        public DataManager1C()
        {
            soap = new ПФ_ПорталДПОPortTypeClient(ПФ_ПорталДПОPortTypeClient.EndpointConfiguration.ПФ_ПорталДПОSoap);
        }

        SOAPCategoryRepository Category;

        public ICategoryRepository<ГруппаПрограммыОбучения> Categories => Category ?? (Category = new SOAPCategoryRepository(soap));

        int t = 99;
    }
}
