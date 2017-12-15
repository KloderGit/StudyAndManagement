using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;
using System;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPCategoryRepository
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPCategoryRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        public async Task<ГруппаПрограммыОбучения> GetEntity(dynamic key)
        {
            var itemKey = (string)key;
            var query = await GetList();
            return query.Where(item => item.ГУИД == itemKey).FirstOrDefault();
        }

        public async Task<IQueryable<ГруппаПрограммыОбучения>> GetList()
        {
            var array = await GetAllAsync();
            return array.AsQueryable();
        }

        protected async Task<IEnumerable<ГруппаПрограммыОбучения>> GetAllAsync() {
            var query = await service.ПолучитьГруппыПрограммОбученияAsync();
            return query.@return as IEnumerable<ГруппаПрограммыОбучения>;
        }
    }
}
