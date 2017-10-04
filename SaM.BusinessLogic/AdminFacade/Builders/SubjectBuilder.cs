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
    public class SubjectDirector
    {
        IEducationBuilder builder;

        public SubjectDirector(IEducationBuilder builder)
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

    public class SubjectBuilder : IEducationBuilder
    {
        IEnumerable<SubjectPOCO> serviceItems;
        List<Subject> result = new List<Subject>();

        List<SubjectPOCO> existItems = new List<SubjectPOCO>();
        List<SubjectPOCO> expextItems = new List<SubjectPOCO>();

        public IUnitOfWorkEF database;

        public SubjectBuilder(IEnumerable<SubjectPOCO> serviceItems)
        {
            database = new DataManagerEF();
            this.serviceItems = serviceItems;
        }

        public void GetExistingItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);

            var databaseItemsGUIDs = database.Subjects.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select(di => di.Guid);

            var shareGUIDs = seviceItemsGUIDS.Intersect(databaseItemsGUIDs);

            existItems.AddRange(serviceItems.Where(si => shareGUIDs.Contains(si.Guid)));
        }

        public void GetNewItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);
            var databaseItemsGUIDs = database.Subjects.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select(di => di.Guid);

            var differentGUIDs = seviceItemsGUIDS.Except(databaseItemsGUIDs);

            expextItems.AddRange(serviceItems.Where(si => differentGUIDs.Contains(si.Guid)));
        }

        public void Updated()
        {
            var databaseItems = database.Subjects.GetList().Where(dbItem => existItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList();

            foreach (var item in existItems)
            {
                var databaseItem = databaseItems.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null)
                {
                    databaseItem = item.Adapt(databaseItem);

                    database.Subjects.Update(databaseItem);
                }
            }

            foreach (var item in expextItems)
            {
                var databaseItem = item.Adapt<Subject>();
                database.Subjects.Add(databaseItem);
            }

            database.Save();

            result.AddRange(database.Subjects.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)));
        }

        public IEnumerable<Subject> GetResult()
        {
            return result;
        }
    }
}
