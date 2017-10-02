using Mapster;
using SaM.Common.DTO;
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
            builder.MarkAsUpdated();
        }
    }

    public class CertificationTypesBuilder : IEducationBuilder
    {
        IEnumerable<CertificationTypeDTO> serviceItems;
        List<CertificationType> result = new List<CertificationType>();

        public IUnitOfWorkEF database;

        public CertificationTypesBuilder(IEnumerable<CertificationTypeDTO> serviceItems)
        {
            database = new DataManagerEF();
            this.serviceItems = serviceItems;
        }


        public void GetExistingItems()
        {
            var databaseItems = database.CertificationTypes.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid.ToString()));

            result.AddRange(databaseItems);
        }

        public void GetNewItems()
        {
            var serviceItemsGIUDs = serviceItems.Select(i => i.Guid);

            var databaseItems = database.CertificationTypes.GetList()
                                .Where(dbItem => serviceItemsGIUDs.Contains(dbItem.Guid.ToString()));

            var databaseItemsGUIDs = databaseItems.Select(dbi => dbi.Guid.ToString());

            var differentGUIDs = serviceItemsGIUDs.Except(databaseItemsGUIDs);

            foreach (var item in serviceItems.Where(serI => differentGUIDs.Contains(serI.Guid)))
            {
                database.CertificationTypes.Add(item.Adapt<CertificationTypeDTO, CertificationType>());
            }

            database.Save();

            var newItems = database.CertificationTypes.GetList().Where(dbItem => differentGUIDs.Contains(dbItem.Guid.ToString()));

            result.AddRange(newItems);
        }

        public void MarkAsUpdated()
        {
            foreach (var item in serviceItems)
            {
                var databaseItem = result.FirstOrDefault( sI => sI.Guid.ToString() == item.Guid );
                databaseItem = item.Adapt(databaseItem);

                database.CertificationTypes.Update(databaseItem);
            }
        }

        public IEnumerable<CertificationType> GetResult()
        {
            return result;
        }
    }
}
