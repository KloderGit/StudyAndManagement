using Mapster;
using SaM.Common.DTO;
using SaM.Domain.Core.Education;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.Infrastructure.Mapster
{
    public class ConfigEntityToDTO : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //  Маппинг Программы обучения

            config.NewConfig<Category, CategoryDTO>();

        }
    }
}
