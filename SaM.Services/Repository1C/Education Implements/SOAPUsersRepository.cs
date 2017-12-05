using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;
using System;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPUsersRepository : ICommonRepository<ГруппаПрограммыОбучения>
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPUsersRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

    }
}
