using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;
using System;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPGroupRepository
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPGroupRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        public async Task<Группа> GetEntity(dynamic key)
        {
            var itemKey = (string)key;
            var query = await GetList();
            return query.Where(item => item.ГУИД == itemKey).FirstOrDefault();
        }

        public async Task<IQueryable<Группа>> GetList()
        {
            var array = await GetAllAsync();
            return array.AsQueryable();
        }

        protected async Task<IEnumerable<Группа>> GetAllAsync() {
            var query = await service.ПолучитьГруппыAsync();
            return query.@return as IEnumerable<Группа>;
        }
    }
}
