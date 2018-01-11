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
    public class SubjectFacade : IEducationFacade<Subject>
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

        public async Task<IEnumerable<Subject>> Get()
        {
            return await db.Subjects.ToListAsync();
        }

        public async Task<IEnumerable<SubjectDTO>> GetDTO()
        {
            var query = await Get();
            return query.Adapt<IEnumerable<SubjectDTO>>();
        }

        public async Task<IEnumerable<Subject>> GetFromService()
        {
            var query = await service.Subjects.GetList();
            return query.Adapt<IEnumerable<Subject>>();
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

        public async Task<int> Update(Subject item)
        {
            var databaseItem = db.Subjects.FirstOrDefault(sI => sI.Guid == item.Guid);
            if (databaseItem != null && !item.EqualService(databaseItem))
            {
                databaseItem = item.Adapt(databaseItem);
                db.Subjects.Update(databaseItem);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<Subject> items)
        {
            foreach (var item in items)
            {
                var databaseItem = db.Subjects.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null && !item.EqualService(databaseItem))
                {
                    databaseItem = item.Adapt(databaseItem);
                    db.Subjects.Update(databaseItem);
                }
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> UpdateFromService()
        {
            var dbItems = await Get();
            var serviceItems = await GetFromService();

            var updateItems = serviceItems.Intersect<Subject>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<Subject>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

        public async Task<int> UpdateFromService(IEnumerable<Subject> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<Subject>(new GuidComparer());

            var updateItems = serviceItems.Intersect<Subject>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<Subject>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }
    }
}
