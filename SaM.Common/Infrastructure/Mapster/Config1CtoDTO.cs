using Mapster;
using SaM.Common.DTO;
using SoapService1C;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.Infrastructure.Mapster
{
    public class Config1CtoDTO : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ГруппаПрограммыОбучения, CategoryDTO>()
                .Map(d => d.Guid, s => s.ГУИД)
                .Map(d => d.Title, s => s.Наименование);
        }
    }
}
