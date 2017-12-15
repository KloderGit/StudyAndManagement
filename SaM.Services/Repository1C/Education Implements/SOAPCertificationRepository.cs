using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPCertificationRepository
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPCertificationRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        public async Task<ФормаКонтроля> GetEntity(dynamic key)
        {
            var itemKey = (string)key;
            var query = await GetList();
            return query.Where(item => item.ГУИД == itemKey).FirstOrDefault();
        }

        public async Task<IQueryable<ФормаКонтроля>> GetList()
        {
            var query = await GetAllAsync();
            return query.AsQueryable();
        }

        public async Task<IEnumerable<ФормаКонтроля>> GetAllAsync()
        {
            var query = await service.ПолучитьФормыКонтроляAsync();
            return query.@return as IEnumerable<ФормаКонтроля>;
        }
    }
}
