using Mapster;
using SaM.BusinessLogic.AdminFacade.UpdateEntity;
using SaM.Common.DTO;
using SaM.Common.Infrastructure.Mapster;
using SaM.Domain.Core.Education;
using SoapService1full;
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

            var prov = new  UpdateEducationType();
            prov.UpdateFromService();


            //var provider = new CommonUpdateEntity<ГруппаПрограммыОбучения, CategoryDTO, Category>();

            //provider.UpdateFromService();
        }

    }
}
