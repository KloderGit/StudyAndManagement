using Mapster;
using SaM.Common.POCO;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.Builders
{


    public class CategoryDirector
    {
        IEducationBuilder builder;

        public CategoryDirector(IEducationBuilder builder)
        {
            this.builder = builder;
        }

        public void Build()
        {
            builder.GetExistingItems();
            builder.GetNewItems();
            builder.Updated();
        }
    }

    public class CategoryBuilder : IEducationBuilder
    {
        IEnumerable<CategoryPOCO> serviceItems;
        List<Category> result = new List<Category>();

        List<CategoryPOCO> existItems = new List<CategoryPOCO>();
        List<CategoryPOCO> expextItems = new List<CategoryPOCO>();

        public IUnitOfWorkEF database;

        public CategoryBuilder(IEnumerable<CategoryPOCO> serviceItems)
        {
            database = new DataManagerEF();
            this.serviceItems = serviceItems;
        }


        public void GetExistingItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);

            var databaseItemsGUIDs = database.Categories.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select(di => di.Guid);

            var shareGUIDs = seviceItemsGUIDS.Intersect(databaseItemsGUIDs);

            existItems.AddRange(serviceItems.Where(si => shareGUIDs.Contains(si.Guid)));
        }

        public void GetNewItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);
            var databaseItemsGUIDs = database.Categories.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select(di => di.Guid);

            var differentGUIDs = seviceItemsGUIDS.Except(databaseItemsGUIDs);

            expextItems.AddRange(serviceItems.Where(si => differentGUIDs.Contains(si.Guid)));
        }

        public void Updated()
        {
            var databaseItems = database.Categories.GetList().Where(dbItem => existItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList();

            foreach (var item in existItems)
            {
                var databaseItem = databaseItems.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null)
                {
                    databaseItem = item.Adapt(databaseItem);

                    database.Categories.Update(databaseItem);
                }
            }

            foreach (var item in expextItems)
            {
                var databaseItem = item.Adapt<Category>();
                database.Categories.Add(databaseItem);
            }

            database.Save();

            result.AddRange(database.Categories.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)));
        }

        public IEnumerable<Category> GetResult()
        {
            return result;
        }
    }
}
