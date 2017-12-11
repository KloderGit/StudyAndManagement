using Mapster;
using SaM.Common.POCO;
using SaM.DataBases.EntityFramework;
using SaM.DataBases.Interfaces;
using SaM.Domain.Core.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.Builders
{

    public class EducationTypeDirector
    {
        IEducationBuilder builder;

        public EducationTypeDirector(IEducationBuilder builder)
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

    public class EducationTypeBuilder : IEducationBuilder
    {

        IEnumerable<EducationTypePOCO> serviceItems;
        List<EducationType> result = new List<EducationType>();

        List<EducationTypePOCO> existItems = new List<EducationTypePOCO>();
        List<EducationTypePOCO> expextItems = new List<EducationTypePOCO>();

        public IUnitOfWorkEF database;

        public EducationTypeBuilder(IEnumerable<EducationTypePOCO> serviceItems)
        {
            database = new DataManagerEF();
            this.serviceItems = serviceItems;
        }

        public void GetExistingItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);

            //var erer = database.EducationTypes.GetList();

            var databaseItemsGUIDs = database.EducationTypes.GetList()
                .Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select(di => di.Guid);

            var shareGUIDs = seviceItemsGUIDS.Intersect(databaseItemsGUIDs);

            existItems.AddRange(serviceItems.Where(si => shareGUIDs.Contains(si.Guid)));
        }

        public void GetNewItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);
            var databaseItemsGUIDs = database.EducationTypes.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select(di => di.Guid);

            var differentGUIDs = seviceItemsGUIDS.Except(databaseItemsGUIDs);

            expextItems.AddRange(serviceItems.Where(si => differentGUIDs.Contains(si.Guid)));
        }

        public void Updated()
        {
            var databaseItems = database.EducationTypes.GetList().Where(dbItem => existItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList();

            foreach (var item in existItems)
            {
                var databaseItem = databaseItems.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null)
                {
                    databaseItem = item.Adapt(databaseItem);

                    database.EducationTypes.Update(databaseItem);
                }
            }

            foreach (var item in expextItems)
            {
                var databaseItem = item.Adapt<EducationType>();
                database.EducationTypes.Add(databaseItem);
            }

            database.Save();

            result.AddRange(database.EducationTypes.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)));
        }

        public IEnumerable<EducationType> GetResult()
        {
            return result;
        }
    }
}
