using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;
using System;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPCategoryRepository : ICommonRepository<ГруппаПрограммыОбучения>
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPCategoryRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        public ГруппаПрограммыОбучения GetEntity(dynamic key)
        {
            var itemKey = (string)key;
            return GetList().Where(item => item.ГУИД == itemKey).FirstOrDefault();
        }

        public IQueryable<ГруппаПрограммыОбучения> GetList()
        {
            var array = GetAllAsync();
            return array.Result.AsQueryable();
        }

        protected async Task<IEnumerable<ГруппаПрограммыОбучения>> GetAllAsync() {
            var query = await service.ПолучитьГруппыПрограммОбученияAsync();
            return query.@return as IEnumerable<ГруппаПрограммыОбучения>;
        }
    }
}
