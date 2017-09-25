using Mapster;
using SaM.BusinessLogic.AdminFacade.UpdateEntity;
using SaM.Common.Infrastructure.Mapster;
using System.Reflection;

namespace SaM.BusinessLogic.AdminFacade
{
    public class AdminFacade
    {
        public AdminFacade()
        {
            Assembly assem = typeof(Config1CtoDTO).GetTypeInfo().Assembly;
            TypeAdapterConfig.GlobalSettings.Scan(assem);
        }


        public void UpdateCategory() {
            var provider = new UpdateCategory();

            provider.UpdateFromService();
        }

    }
}
