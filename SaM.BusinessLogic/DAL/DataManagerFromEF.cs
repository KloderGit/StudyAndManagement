using Mapster;
using SaM.Common.POCO;
using SaM.DataBases.EntityFramework;
using SaM.DataBases.Infrastructure;
using SaM.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BusinessLogic.DAL
{
    public class DataManagerFromEF
    {
        IDataManager datamanager;

        public DataManagerFromEF()
        {
            datamanager = new DataManagerEntityFramework();
        }

        public IEnumerable<CategoryPOCO> GetCategories() {
            var query = datamanager.Categories.GetAll()
                .IncludeMultiple( sl => sl.Programs);

            return query.Adapt<IEnumerable<CategoryPOCO>>();
        }
        
    }
}
