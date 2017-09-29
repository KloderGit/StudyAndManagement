using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPEducationTypeRepository : ICommonRepository<ФормаОбучения>
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPEducationTypeRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        protected async Task<IEnumerable<ФормаОбучения>> GetAllAsync()
        {
            var query = await service.ПолучитьФормыОбученияAsync();
            return query.@return as IEnumerable<ФормаОбучения>;
        }

        public IQueryable<ФормаОбучения> GetList()
        {
            var array = GetAllAsync();
            return array.Result.AsQueryable();
        }

        public ФормаОбучения GetEntity(dynamic key)
        {
            var itemKey = (string)key;
            return GetList().Where( item => item.ГУИД == itemKey).FirstOrDefault();
        }
    }
}