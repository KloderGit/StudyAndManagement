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
    public class EducationTypeFacade : IFacade<EducationType>, IServiceFacade<EducationTypeService>
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

        public async Task<IEnumerable<EducationType>> Get()
        {
            return await db.EducationTypes.ToListAsync();
        }

        public async Task<EducationType> Get(Guid guid)
        {
            return await db.EducationTypes.FirstOrDefaultAsync(sI => sI.Guid == guid);
        }

        public async Task<IEnumerable<EducationTypeService>> GetFromService()
        {
            var query = await service.EducationTypes.GetList();
            return query.Adapt<IEnumerable<EducationTypeService>>();
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

        private async void ToSave(EducationType dbItem, EducationType updItem)
        {
            var databaseItem = updItem.Adapt(await Get(updItem.Guid));
            db.EducationTypes.Update(databaseItem);
        }

        public async Task<int> Update(EducationType item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(EducationTypeService item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item.Adapt<EducationType>());
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<EducationType> items)
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

        public async Task<int> Update(IEnumerable<EducationTypeService> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<EducationTypeService>(new GuidComparer());

            var updateItems = serviceItems.Intersect(dbItems, new GuidComparer());

            var newItems = serviceItems.Except(updateItems, new GuidComparer());

            var count = 0;

            foreach (var item in updateItems.Cast<EducationTypeService>())
            {
                count += await Update(item);
            }

            foreach (var item in newItems.Cast<EducationTypeService>())
            {
                count += await Add(item.Adapt<EducationType>());
            }

            return count;
        }

    }
}
