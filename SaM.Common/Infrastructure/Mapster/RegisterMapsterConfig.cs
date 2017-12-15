using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SaM.Common.Infrastructure.Mapster
{
    public class RegisterMapsterConfig 
    {
        public RegisterMapsterConfig()
        {
            Assembly assem = typeof(Config1CtoDTO).GetTypeInfo().Assembly;
            Assembly assem3 = typeof(ConfigEntityToPOCO).GetTypeInfo().Assembly;
            //Assembly assem2 = typeof(Config1CtoPOCO).GetTypeInfo().Assembly; 
            Assembly assem4 = typeof(Config1CtoEntity).GetTypeInfo().Assembly;

            TypeAdapterConfig.GlobalSettings.Scan(assem, assem3, assem4);
        }
    }
}
