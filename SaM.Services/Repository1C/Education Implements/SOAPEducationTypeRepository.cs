using SaM.Domain.Interfaces.Repositories;
using SoapService1C;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SaM.Services.Repository1C
{
    public class SOAPEducationTypeRepository : ImplementRepositorySOAP1C<ФормаОбучения>, ICommonRepository<ФормаОбучения>
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPEducationTypeRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        protected override async Task<IEnumerable<ФормаОбучения>> GetAllAsync()
        {
            var query = await service.ПолучитьФормыОбученияAsync();
            return query.@return as IEnumerable<ФормаОбучения>;
        }

    }
}
