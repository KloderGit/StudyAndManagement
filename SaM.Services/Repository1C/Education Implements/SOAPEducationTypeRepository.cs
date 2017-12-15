using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPEducationTypeRepository
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPEducationTypeRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        public async Task<ФормаОбучения> GetEntity(dynamic key)
        {
            var itemKey = (string)key;
            var query = await GetList();
            return query.Where( item => item.ГУИД == itemKey).FirstOrDefault();
        }

        public async Task<IQueryable<ФормаОбучения>> GetList()
        {
            var array = await GetAllAsync();
            return array.AsQueryable();
        }

        protected async Task<IEnumerable<ФормаОбучения>> GetAllAsync()
        {
            var query = await service.ПолучитьФормыОбученияAsync();
            return query.@return as IEnumerable<ФормаОбучения>;
        }
    }
}