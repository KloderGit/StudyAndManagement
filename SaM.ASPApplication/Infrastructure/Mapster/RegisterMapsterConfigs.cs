using Mapster;
using SaM.Common.Infrastructure.Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SaM.ASPApplication.Infrastructure.Mapster
{
    public class RegisterMapsterConfig
    {
        public RegisterMapsterConfig()
        {
            Assembly assem = typeof(ConfigPOCOtoViewModel).GetTypeInfo().Assembly;

            TypeAdapterConfig.GlobalSettings.Scan(assem);
        }
    }
}
