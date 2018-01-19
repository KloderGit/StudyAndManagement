using Mapster;
using Microsoft.EntityFrameworkCore;
using SaM.Common.DTO;
using SaM.Common.Infrastructure;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using SoapService1full;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SaM.BusinessLogic.Interfaces;
using SaM.Common.ServiceEntity;

namespace SaM.BusinessLogic.Facades.Education
{
    public class CertificationTypeFacade : IFacade<CertificationType>, IServiceFacade<CertificationTypeService>
    {
        ApplicationContext db;
        DataManager1C service;

        public CertificationTypeFacade()
        {
            db = new ApplicationContext();
            service = new DataManager1C();
        }

        public CertificationTypeFacade(ApplicationContext db)
        {
            this.db = db;
            service = new DataManager1C();
        }

        public async Task<IEnumerable<CertificationType>> Get()
        {
            return await db.CertificationTypes.ToListAsync();
        }

        public async Task<CertificationType> Get(Guid guid)
        {
            return await db.CertificationTypes.FirstOrDefaultAsync(sI => sI.Guid == guid);
        }

        public async Task<IEnumerable<CertificationTypeService>> GetFromService()
        {
            var query = await service.EducationPrograms.GetList();

            var types = query.SelectMany(ii => ii.listOfSubjects
                                                 .SelectMany(kk => kk.Attestation.SpisokVariantAttestation)
                                                 .Where(iii => iii.GUIDViewAttestation != ""))
                             .Adapt<IEnumerable<CertificationTypeService>>()
                             .Distinct<CertificationTypeService>(new GuidComparer());

            return types;
        }

        public async Task<int> Remove(Guid guid)
        {
            var elem = db.CertificationTypes.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.CertificationTypes.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Remove(IEnumerable<Guid> guids)
        {
            var toRemove = new List<CertificationType>();

            foreach (var item in guids)
            {
                var elem = db.CertificationTypes.FirstOrDefault(el => el.Guid == item);

                if (elem != null) { toRemove.Add(elem); }
            }

            if (toRemove.Count == 0) { new Exception(" Элементы Не найдены в БД "); }

            db.CertificationTypes.RemoveRange(toRemove);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Add(CertificationType item)
        {
            var databaseItem = item.Adapt<CertificationType>();
            db.CertificationTypes.Add(databaseItem);

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Add(IEnumerable<CertificationType> items)
        {
            foreach (var item in items)
            {
                var databaseItem = item.Adapt<CertificationType>();
                db.CertificationTypes.Add(databaseItem);
            }

            var count = await db.SaveChangesAsync();
            return count;
        }

        private async void ToSave(CertificationType dbItem, CertificationType updItem)
        {
            var databaseItem = updItem.Adapt(await Get(updItem.Guid));
            db.CertificationTypes.Update(databaseItem);
        }

        public async Task<int> Update(CertificationType item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(CertificationTypeService item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item.Adapt<CertificationType>());
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<CertificationType> items)
        {
            var count = 0;

            foreach (var item in items)
            {
                count += await Update(item);
            }

            return count;
        }

        public async Task<int> Update()
        {
            return await Update(await GetFromService());
        }

        public async Task<int> Update(IEnumerable<CertificationTypeService> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<CertificationTypeService>(new GuidComparer());

            var updateItems = serviceItems.Intersect(dbItems, new GuidComparer());

            var newItems = serviceItems.Except(updateItems, new GuidComparer());

            var count = 0;

            foreach (var item in updateItems.Cast<CertificationTypeService>())
            {
                count += await Update(item);
            }

            foreach (var item in newItems.Cast<CertificationTypeService>())
            {
                count += await Add(item.Adapt<CertificationType>());
            }

            return count;
        }

    }

}
