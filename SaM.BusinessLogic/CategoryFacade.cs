using Mapster;
using Microsoft.EntityFrameworkCore;
using SaM.Common.DTO;
using SaM.DataBases.EntityFramework;
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

        public IEnumerable<CategoryDTO> GetDTO()
        {
            return GetPOCO().Adapt<IEnumerable<CategoryDTO>>();
        }

        public IEnumerable<Category> GetFromService()
        {
            return service.Categories.GetList().Adapt<IEnumerable<Category>>(); ;
        }

        public async Task<int> RemoveItem( Guid guid )
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

        async Task<IEnumerable<Category>> GetExistingItems()
        {
            return GetFromService().Intersect(await GetPOCO());
        }

        async Task<IEnumerable<Category>> GetNewItems()
        {
            var items = await GetExistingItems();

            return items.Except(GetFromService());
        }

        public async Task<int> Update()
        {
            foreach (var item in await GetExistingItems())
            {
                var databaseItem = db.Categories.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null)
                {
                    databaseItem = item.Adapt(databaseItem);
                    db.Categories.Update(databaseItem);
                }
            }

            foreach (var item in await GetNewItems())
            {
                var databaseItem = item.Adapt<Category>();
                db.Categories.Add(databaseItem);
            }

            return await db.SaveChangesAsync();
        }


    }
}
