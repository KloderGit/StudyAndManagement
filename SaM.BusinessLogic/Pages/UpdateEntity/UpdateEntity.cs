using Mapster;
using SaM.Common.DTO;
using SaM.Services.Repository1C;
using SoapService1C;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SaM.BusinessLogic.Pages.UpdateEntity
{
    public class UpdateEntity
    {
        IDataManager1C datamanager;

        public UpdateEntity()
        {
            datamanager = new DataManager1C();

            TypeAdapterConfig<ГруппаПрограммыОбучения, CategoryDTO>.NewConfig()
                .Map(d => d.Guid, s => s.ГУИД)
                .Map(d => d.Title, s => s.Наименование);
        }

        public IEnumerable<CategoryDTO> GetCategory() {

            var query = datamanager.Categories.GetAll().ToList() as IEnumerable<ГруппаПрограммыОбучения>;
            var result = query.Adapt<IEnumerable<CategoryDTO>>();

            return result;
        }


    }
}
