using Mapster;
using SaM.Common.DTO;
using SaM.Common.POCO;
using SaM.DataBases.EntityFramework;
using SaM.DataBases.Infrastructure;
using SaM.Domain.Core.Education;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.Builders
{

    public class CertificationDirector
    {
        IEducationBuilder builder;

        public CertificationDirector(IEducationBuilder builder)
        {
            this.builder = builder;
        }

        public void Build()
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.Write("GetExistingItems - ");

            builder.GetExistingItems();
            sw.Stop();
            Console.WriteLine((sw.ElapsedMilliseconds / 100.0).ToString());

            sw.Reset();
            sw.Start();
            Console.Write("GetNewItems - ");
            builder.GetNewItems();
            sw.Stop();
            Console.WriteLine((sw.ElapsedMilliseconds / 100.0).ToString());

            sw.Reset();
            sw.Start();
            Console.Write("Updated - ");
            builder.Updated();
            sw.Stop();
            Console.WriteLine((sw.ElapsedMilliseconds / 100.0).ToString());
        }
    }

    public class CertificationBuilder : IEducationBuilder
    {

        IEnumerable<CertificationPOCO> serviceItems;
        List<Certification> result = new List<Certification>();

        List<CertificationPOCO> existItems = new List<CertificationPOCO>();
        List<CertificationPOCO> expextItems = new List<CertificationPOCO>();

        public IUnitOfWorkEF database;

        public CertificationBuilder(IEnumerable<CertificationPOCO> serviceItems)
        {
            database = new DataManagerEF();
            this.serviceItems = serviceItems;
        }

        public void GetExistingItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);

            var databaseItemsGUIDs = database.Certifications.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select( di => di.Guid);

            var shareGUIDs = seviceItemsGUIDS.Intersect(databaseItemsGUIDs);

            existItems.AddRange( serviceItems.Where( si => shareGUIDs.Contains(si.Guid) ) );
        }

        public void GetNewItems()
        {
            var seviceItemsGUIDS = serviceItems.Select(si => si.Guid);
            var databaseItemsGUIDs = database.Certifications.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList().Select(di => di.Guid);

            var differentGUIDs = seviceItemsGUIDS.Except(databaseItemsGUIDs);

            expextItems.AddRange(serviceItems.Where(si => differentGUIDs.Contains(si.Guid)));
        }

        public void Updated()
        {
            var databaseItems = database.Certifications.GetList().Where(dbItem => existItems.Select(gd => gd.Guid).Contains(dbItem.Guid)).ToList();

            foreach (var item in existItems)
            {
                var databaseItem = databaseItems.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null)
                {
                    databaseItem = item.Adapt(databaseItem);

                    database.Certifications.Update(databaseItem);
                }
            }

            foreach (var item in expextItems)
            {
                var databaseItem = item.Adapt<Certification>();
                database.Certifications.Add(databaseItem);
            }

            database.Save();

            result.AddRange(database.Certifications.GetList().Where(dbItem => serviceItems.Select(gd => gd.Guid).Contains(dbItem.Guid)));
        }

        public IEnumerable<Certification> GetResult()
        {
            return result;
        }
    }
}
