using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPCertificationRepository : ICommonRepository<ФормаКонтроля>
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPCertificationRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        public ФормаКонтроля GetEntity(dynamic key)
        {
            var itemKey = (string)key;
            return GetList().Where(item => item.ГУИД == itemKey).FirstOrDefault();
        }

        public IQueryable<ФормаКонтроля> GetList()
        {
            var array = GetAllAsync();
            return array.Result.AsQueryable();
        }

        public async Task<IEnumerable<ФормаКонтроля>> GetAllAsync()
        {
            var query = await service.ПолучитьФормыКонтроляAsync();
            return query.@return as IEnumerable<ФормаКонтроля>;
        }
    }
}
