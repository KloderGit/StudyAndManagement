using SaM.Domain.Interfaces.Repositories;
using SoapService1C;

using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Services.Repository1C
{
    public interface IDataManager1C
    {
        ICategoryRepository<ГруппаПрограммыОбучения> Categories { get; }

    }
}
