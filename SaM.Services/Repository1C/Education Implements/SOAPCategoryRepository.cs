using SaM.Domain.Interfaces.Repositories;
using SoapService1C;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SaM.Services.Repository1C
{
    public class SOAPCategoryRepository : ImplementRepositorySOAP1C<ГруппаПрограммыОбучения>, ICommonRepository<ГруппаПрограммыОбучения>
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPCategoryRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        protected override async Task<IEnumerable<ГруппаПрограммыОбучения>> GetAllAsync() {
            var query = await service.ПолучитьГруппыПрограммОбученияAsync();
            return query.@return as IEnumerable<ГруппаПрограммыОбучения>;
        }

    }
}
