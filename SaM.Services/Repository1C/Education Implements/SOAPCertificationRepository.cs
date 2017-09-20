using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;

namespace SaM.Services.Repository1C
{
    public class SOAPCertificationRepository : ImplementRepositorySOAP1C<ФормаКонтроля>, ICommonRepository<ФормаКонтроля>
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPCertificationRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        protected override async Task<IEnumerable<ФормаКонтроля>> GetAllAsync()
        {
            var query = await service.ПолучитьФормыКонтроляAsync();
            return query.@return as IEnumerable<ФормаКонтроля>;
        }

    }
}
