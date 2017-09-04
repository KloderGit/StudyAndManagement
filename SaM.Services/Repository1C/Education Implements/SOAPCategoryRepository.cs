using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using SoapService1C;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace SaM.Services.Repository1C
{
    public class SOAPCategoryRepository: ImplementRepositorySOAP1C<ГруппаПрограммыОбучения>, ICategoryRepository<ГруппаПрограммыОбучения>
    {
        public SOAPCategoryRepository(ПФ_ПорталДПОPortTypeClient soap) : base (soap)
        {
        }

        private async Task<IEnumerable<ГруппаПрограммыОбучения>> GetCategoryAsynk() {
            var query = await datamanager.ПолучитьГруппыПрограммОбученияAsync();
            return query.@return as IEnumerable<ГруппаПрограммыОбучения>;
        }
    }
}
