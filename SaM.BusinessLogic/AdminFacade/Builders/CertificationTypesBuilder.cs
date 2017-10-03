using Mapster;
using SaM.Common.DTO;
using SaM.Common.POCO;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.Builders
{

    public class CertificationTypesDirector
    {
        IEducationBuilder builder;

        public CertificationTypesDirector( IEducationBuilder builder )
        {
            this.builder = builder;
        }

        public void Build() {
            builder.GetExistingItems();
            builder.GetNewItems();
            builder.Updated();
        }
    }

    public class CertificationTypesBuilder : IEducationBuilder
    {
        IEnumerable<CertificationTypePOCO> serviceItems;
        List<CertificationType> result = new List<CertificationType>();

        List<CertificationTypePOCO> existItems = new List<CertificationTypePOCO>();
        List<CertificationTypePOCO> expextItems = new List<CertificationTypePOCO>();

        public IUnitOfWorkEF database;

        public CertificationTypesBuilder(IEnumerable<CertificationTypePOCO> serviceItems)
        {
            database = new DataManagerEF();
            this.serviceItems = serviceItems;
        }


        public void GetExistingItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);
            var databaseItemsGUIDs = database.CertificationTypes.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select(di => di.Guid);

            var shareGUIDs = seviceItemsGUIDS.Intersect(databaseItemsGUIDs);

            existItems.AddRange(serviceItems.Where(si => shareGUIDs.Contains(si.Guid)));
        }

        public void GetNewItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);
            var databaseItemsGUIDs = database.CertificationTypes.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select(di => di.Guid);

            var differentGUIDs = seviceItemsGUIDS.Except(databaseItemsGUIDs);

            expextItems.AddRange(serviceItems.Where(si => differentGUIDs.Contains(si.Guid)));
        }

        public void Updated()
        {
            var databaseItems = database.CertificationTypes.GetList().Where(dbItem => existItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList();

            foreach (var item in existItems)
            {
                var databaseItem = databaseItems.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null)
                {
                    databaseItem = item.Adapt(databaseItem);

                    database.CertificationTypes.Update(databaseItem);
                }
            }

            foreach (var item in expextItems)
            {
                var databaseItem = item.Adapt<CertificationType>();
                database.CertificationTypes.Add(databaseItem);
            }

            database.Save();

            result.AddRange(database.CertificationTypes.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)));
        }

        public IEnumerable<CertificationType> GetResult()
        {
            return result;
        }
    }
}
