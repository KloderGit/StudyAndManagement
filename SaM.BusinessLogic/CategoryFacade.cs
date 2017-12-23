using Mapster;
using Microsoft.EntityFrameworkCore;
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
    public class CategoryFacade
    {
        ApplicationContext db = new ApplicationContext();
        DataManager1C service = new DataManager1C();

        public async Task<IEnumerable<Category>> GetPOCO()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<IEnumerable<CategoryDTO>> GetDTO()
        {
            var query = await GetPOCO();
            return query.Adapt<IEnumerable<CategoryDTO>>();
        }

        public async Task<IEnumerable<Category>> GetFromService()
        {
            var query = await service.Categories.GetList();
            return query.Adapt<IEnumerable<Category>>();
        }

        public async Task<int> RemoveItem(Guid guid)
        {
            var elem = db.Categories.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.Categories.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> RemoveItems(IEnumerable<Guid> guids)
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

        public async Task<int> Update(Category item)
        {
            var databaseItem = db.Categories.FirstOrDefault(sI => sI.Guid == item.Guid);
            if (databaseItem != null && !item.EqualService(databaseItem))
            {
                databaseItem = item.Adapt(databaseItem);
                db.Categories.Update(databaseItem);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<Category> incoming)
        {
            foreach (var item in incoming)
            {
                var databaseItem = db.Categories.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null && !item.EqualService(databaseItem))
                {
                    databaseItem = item.Adapt(databaseItem);
                    db.Categories.Update(databaseItem);
                }
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> UpdateFromService()
        {
            var dbItems = await GetPOCO();
            var serviceItems = await GetFromService();

            var updateItems = serviceItems.Intersect<Category>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<Category>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

        public async Task<int> UpdateFromService(IEnumerable<Category> incoming)
        {
            Console.WriteLine("Обновление Категорий из полученных данных");

            var dbItems = await GetPOCO();
            var serviceItems = incoming;

            var updateItems = serviceItems.Intersect<Category>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<Category>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }


    }
}
