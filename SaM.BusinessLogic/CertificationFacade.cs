using Mapster;
using Microsoft.EntityFrameworkCore;
using SaM.BusinessLogic.Interfaces;
using SaM.Common.DTO;
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

namespace SaM.BusinessLogic
{
    public class CertificationFacade : IEducationFacade<Certification>
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

        public async Task<IEnumerable<CertificationDTO>> GetDTO()
        {
            var query = await Get();
            return query.Adapt<IEnumerable<CertificationDTO>>();
        }

        public async Task<IEnumerable<Certification>> GetFromService()
        {
            var query = await service.Certifications.GetList();
            return query.Adapt<IEnumerable<Certification>>();
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

        public async Task<int> Update(Certification item)
        {
            var databaseItem = db.Certifications.FirstOrDefault(sI => sI.Guid == item.Guid);
            if (databaseItem != null && !item.EqualService(databaseItem))
            {
                databaseItem = item.Adapt(databaseItem);
                db.Certifications.Update(databaseItem);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<Certification> items)
        {
            foreach (var item in items)
            {
                var databaseItem = db.Certifications.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null && !item.EqualService(databaseItem))
                {
                    databaseItem = item.Adapt(databaseItem);
                    db.Certifications.Update(databaseItem);
                }
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> UpdateFromService()
        {
            var dbItems = await Get();
            var serviceItems = await GetFromService();

            var updateItems = serviceItems.Intersect<Certification>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<Certification>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

        public async Task<int> UpdateFromService(IEnumerable<Certification> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<Certification>(new GuidComparer());

            var updateItems = serviceItems.Intersect<Certification>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<Certification>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

    }

}
