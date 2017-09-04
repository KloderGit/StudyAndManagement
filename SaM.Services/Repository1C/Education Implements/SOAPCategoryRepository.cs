﻿using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using SoapService1C;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace SaM.Services.Repository1C
{
    public class SOAPCategoryRepository : ImplementRepositorySOAP1C<ГруппаПрограммыОбучения>, ICategoryRepository<ГруппаПрограммыОбучения>
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPCategoryRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
            datamanager = new GetAllDelegate(GetAllAsync);
        }

        public async Task<IEnumerable<ГруппаПрограммыОбучения>> GetAllAsync() {
            var query = await service.ПолучитьГруппыПрограммОбученияAsync();
            return query.@return as IEnumerable<ГруппаПрограммыОбучения>;
        }

    }
}
