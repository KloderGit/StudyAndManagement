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
    public class CertificationFacade : IFacade<Certification>, IServiceFacade<CertificationService>
    {
        ApplicationContext db;
        DataManager1C service;

        public CertificationFacade()
        {
            db = new ApplicationContext();
            service = new DataManager1C();
        }

        public CertificationFacade(ApplicationContext db)
        {
            this.db = db;
            service = new DataManager1C();
        }

        public async Task<IEnumerable<Certification>> Get()
        {
            return await db.Certifications.ToListAsync();
        }

        public async Task<Certification> Get(Guid guid)
        {
            return await db.Certifications.FirstOrDefaultAsync(sI => sI.Guid == guid);
        }

        public async Task<IEnumerable<CertificationService>> GetFromService()
        {
            var query = await service.Certifications.GetList();
            return query.Adapt<IEnumerable<CertificationService>>();
        }

        public async Task<int> Remove(Guid guid)
        {
            var elem = db.Certifications.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.Certifications.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Remove(IEnumerable<Guid> guids)
        {
            var toRemove = new List<Certification>();

            foreach (var item in guids)
            {
                var elem = db.Certifications.FirstOrDefault(el => el.Guid == item);

                if (elem != null) { toRemove.Add(elem); }
            }

            if (toRemove.Count == 0) { new Exception(" Элементы Не найдены в БД "); }

            db.Certifications.RemoveRange(toRemove);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Add(Certification item)
        {
            var databaseItem = item.Adapt<Certification>();
            db.Certifications.Add(databaseItem);

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Add(IEnumerable<Certification> items)
        {
            foreach (var item in items)
            {
                var databaseItem = item.Adapt<Certification>();
                db.Certifications.Add(databaseItem);
            }

            var count = await db.SaveChangesAsync();
            return count;
        }

        private async void ToSave(Certification dbItem, Certification updItem)
        {
            var databaseItem = updItem.Adapt(await Get(updItem.Guid));
            db.Certifications.Update(databaseItem);
        }

        public async Task<int> Update(Certification item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(CertificationService item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item.Adapt<Certification>());
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<Certification> items)
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

        public async Task<int> Update(IEnumerable<CertificationService> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<CertificationService>(new GuidComparer());

            var updateItems = serviceItems.Intersect(dbItems, new GuidComparer());

            var newItems = serviceItems.Except(updateItems, new GuidComparer());

            var count = 0;

            foreach (var item in updateItems.Cast<CertificationService>())
            {
                count += await Update(item);
            }

            foreach (var item in newItems.Cast<CertificationService>())
            {
                count += await Add(item.Adapt<Certification>());
            }

            return count;
        }

    }

}
