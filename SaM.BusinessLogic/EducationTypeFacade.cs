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
using System.Reflection;

namespace SaM.BusinessLogic
{
    public class EducationTypeFacade : IEducationFacade<EducationType>
    {
        ApplicationContext db;
        DataManager1C service;

        public EducationTypeFacade()
        {
            db = new ApplicationContext();
            service = new DataManager1C();
        }

        public EducationTypeFacade(ApplicationContext db)
        {
            this.db = db;
            service = new DataManager1C();
        }

        public async Task<int> Add(EducationType item)
        {
            var databaseItem = item.Adapt<EducationType>();
            db.EducationTypes.Add(databaseItem);

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Add(IEnumerable<EducationType> items)
        {
            foreach (var item in items)
            {
                var databaseItem = item.Adapt<EducationType>();
                db.EducationTypes.Add(databaseItem);
            }

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<IEnumerable<EducationType>> Get()
        {
            return await db.EducationTypes.ToListAsync();
        }

        public async Task<IEnumerable<EducationTypeDTO>> GetDTO()
        {
            var query = await Get();
            return query.Adapt<IEnumerable<EducationTypeDTO>>();
        }

        public async Task<IEnumerable<EducationType>> GetFromService()
        {
            var query = await service.EducationTypes.GetList();
            return query.Adapt<IEnumerable<EducationType>>();
        }

        public async Task<int> Remove(Guid guid)
        {
            var elem = db.EducationTypes.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.EducationTypes.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Remove(IEnumerable<Guid> guids)
        {
            var toRemove = new List<EducationType>();

            foreach (var item in guids)
            {
                var elem = db.EducationTypes.FirstOrDefault(el => el.Guid == item);

                if (elem != null) { toRemove.Add(elem); }
            }

            if (toRemove.Count == 0) { new Exception(" Элементы Не найдены в БД "); }

            db.EducationTypes.RemoveRange(toRemove);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Update(EducationType item)
        {
            var databaseItem = db.EducationTypes.FirstOrDefault(sI => sI.Guid == item.Guid);
            if (databaseItem != null && !item.EqualService(databaseItem))
            {
                databaseItem = item.Adapt(databaseItem);
                db.EducationTypes.Update(databaseItem);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<EducationType> items)
        {
            foreach (var item in items)
            {
                var databaseItem = db.EducationTypes.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null && !item.EqualService(databaseItem))
                {
                    databaseItem = item.Adapt(databaseItem);
                    db.EducationTypes.Update(databaseItem);
                }
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> UpdateFromService()
        {
            var dbItems = await Get();
            var serviceItems = await GetFromService();

            var updateItems = serviceItems.Intersect<EducationType>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<EducationType>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

        public async Task<int> UpdateFromService(IEnumerable<EducationType> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<EducationType>(new GuidComparer());

            var updateItems = serviceItems.Intersect<EducationType>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<EducationType>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }
    }
}
