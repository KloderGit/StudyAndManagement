using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;
using System;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPSubjectRepository
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPSubjectRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        public async Task<Дисциплина> GetEntity(dynamic key)
        {
            var itemKey = (string)key;
            var query = await GetList();
            return query.Where(item => item.ГУИД == itemKey).FirstOrDefault();
        }

        public async Task<IQueryable<Дисциплина>> GetList()
        {
            var array = await GetAllAsync();
            return array.AsQueryable();
        }

        protected async Task<IEnumerable<Дисциплина>> GetAllAsync() {
            var query = await service.ПолучитьДисциплиныAsync();
            return query.@return as IEnumerable<Дисциплина>;
        }
    }
}
