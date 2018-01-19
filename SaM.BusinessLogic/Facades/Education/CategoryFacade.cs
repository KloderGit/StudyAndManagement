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
    public class CategoryFacade : IFacade<Category>, IServiceFacade<CategoryService>
    {
        ApplicationContext db;
        DataManager1C service;

        public CategoryFacade()
        {
            db = new ApplicationContext();
            service = new DataManager1C();
        }

        public CategoryFacade(ApplicationContext db)
        {
            this.db = db;
            service = new DataManager1C();
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<Category> Get(Guid guid )
        {
            return await db.Categories.FirstOrDefaultAsync(sI => sI.Guid == guid);
        }

        public async Task<IEnumerable<CategoryService>> GetFromService()
        {
            var query = await service.Categories.GetList();
            return query.Adapt<IEnumerable<CategoryService>>();
        }

        public async Task<int> Remove(Guid guid)
        {
            var elem = db.Categories.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.Categories.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Remove(IEnumerable<Guid> guids)
        {
            var toRemove = new List<Category>();

            foreach (var item in guids)
            {
                var elem = db.Categories.FirstOrDefault(el => el.Guid == item);

                if (elem != null) { toRemove.Add(elem); }
            }

            if (toRemove.Count == 0) { new Exception(" Элементы Не найдены в БД "); }

            db.Categories.RemoveRange(toRemove);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Add(Category item)
        {
            var databaseItem = item.Adapt<Category>();
            db.Categories.Add(databaseItem);

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Add(IEnumerable<Category> items)
        {
            foreach (var item in items)
            {
                var databaseItem = item.Adapt<Category>();
                db.Categories.Add(databaseItem);
            }

            var count = await db.SaveChangesAsync();
            return count;
        }

        private async void ToSave(Category dbItem, Category updItem)
        {
            var databaseItem = updItem.Adapt(await Get(updItem.Guid));
            db.Categories.Update(databaseItem);
        }

        public async Task<int> Update(Category item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(CategoryService item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item.Adapt<Category>());
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<Category> items)
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
            return await Update( await GetFromService() );
        }

        public async Task<int> Update(IEnumerable<CategoryService> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<CategoryService>(new GuidComparer());

            var updateItems = serviceItems.Intersect(dbItems, new GuidComparer());

            var newItems = serviceItems.Except(updateItems, new GuidComparer());

            var count = 0;

            foreach (var item in updateItems.Cast<CategoryService>())
            {
                count += await Update(item);
            }

            foreach (var item in newItems.Cast<CategoryService>())
            {
                count += await Add(item.Adapt<Category>());
            }

            return count;
        }

    }
}
