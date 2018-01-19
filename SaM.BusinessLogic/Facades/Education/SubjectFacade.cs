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
    public class SubjectFacade : IFacade<Subject>, IServiceFacade<SubjectService>
    {
        ApplicationContext db;
        DataManager1C service;

        public SubjectFacade()
        {
            db = new ApplicationContext();
            service = new DataManager1C();
        }

        public SubjectFacade(ApplicationContext db)
        {
            this.db = db;
            service = new DataManager1C();
        }

        public async Task<IEnumerable<Subject>> Get()
        {
            return await db.Subjects.ToListAsync();
        }

        public async Task<Subject> Get(Guid guid)
        {
            return await db.Subjects.FirstOrDefaultAsync(sI => sI.Guid == guid);
        }

        public async Task<IEnumerable<SubjectService>> GetFromService()
        {
            var query = await service.Subjects.GetList();
            return query.Adapt<IEnumerable<SubjectService>>();
        }

        public async Task<int> Remove(Guid guid)
        {
            var elem = db.Subjects.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.Subjects.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Remove(IEnumerable<Guid> guids)
        {
            var toRemove = new List<Subject>();

            foreach (var item in guids)
            {
                var elem = db.Subjects.FirstOrDefault(el => el.Guid == item);

                if (elem != null) { toRemove.Add(elem); }
            }

            if (toRemove.Count == 0) { new Exception(" Элементы Не найдены в БД "); }

            db.Subjects.RemoveRange(toRemove);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Add(Subject item)
        {
            var databaseItem = item.Adapt<Subject>();
            db.Subjects.Add(databaseItem);

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Add(IEnumerable<Subject> items)
        {
            foreach (var item in items)
            {
                var databaseItem = item.Adapt<Subject>();
                db.Subjects.Add(databaseItem);
            }

            var count = await db.SaveChangesAsync();
            return count;
        }

        private async void ToSave(Subject dbItem, Subject updItem)
        {
            var databaseItem = updItem.Adapt(await Get(updItem.Guid));
            db.Subjects.Update(databaseItem);
        }

        public async Task<int> Update(Subject item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(SubjectService item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item.Adapt<Subject>());
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<Subject> items)
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

        public async Task<int> Update(IEnumerable<SubjectService> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<SubjectService>(new GuidComparer());

            var updateItems = serviceItems.Intersect(dbItems, new GuidComparer());

            var newItems = serviceItems.Except(updateItems, new GuidComparer());

            var count = 0;

            foreach (var item in updateItems.Cast<SubjectService>())
            {
                count += await Update(item);
            }

            foreach (var item in newItems.Cast<SubjectService>())
            {
                count += await Add(item.Adapt<Subject>());
            }

            return count;
        }

    }
}
