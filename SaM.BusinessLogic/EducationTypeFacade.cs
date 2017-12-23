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
    public class EducationTypeFacade
    {
        ApplicationContext db = new ApplicationContext();
        DataManager1C service = new DataManager1C();

        public async Task<IEnumerable<EducationType>> GetPOCO()
        {
            return await db.EducationTypes.ToListAsync();
        }

        public async Task<IEnumerable<EducationTypeDTO>> GetDTO()
        {
            var query = await GetPOCO();
            return query.Adapt<IEnumerable<EducationTypeDTO>>();
        }

        public async Task<IEnumerable<EducationType>> GetFromService()
        {
            var query = await service.EducationTypes.GetList();
            return query.Adapt<IEnumerable<EducationType>>();
        }

        public async Task<int> RemoveItem(Guid guid)
        {
            var elem = db.EducationTypes.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.EducationTypes.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> RemoveItems(IEnumerable<Guid> guids)
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

        public async Task<int> Update()
        {
            var dbItems = await GetPOCO();
            var serviceItems = await GetFromService();

            var updateItems = serviceItems.Intersect<EducationType>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<EducationType>(updateItems, new GuidComparer());

            foreach (var item in updateItems)
            {
                var databaseItem = db.EducationTypes.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null && !item.EqualService(databaseItem))
                {
                    databaseItem = item.Adapt(databaseItem);
                    db.EducationTypes.Update(databaseItem);
                }
            }

            foreach (var item in newItems)
            {
                var databaseItem = item.Adapt<EducationType>();
                db.EducationTypes.Add(databaseItem);
            }

            var cnt = await db.SaveChangesAsync();

            return cnt;
        }

        public async Task<int> Update(IEnumerable<EducationType> incoming)
        {
            var dbItems = await GetPOCO();
            var serviceItems = incoming;

            var updateItems = serviceItems.Intersect<EducationType>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<EducationType>(updateItems, new GuidComparer());

            foreach (var item in updateItems)
            {
                var databaseItem = db.EducationTypes.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null && !item.EqualService(databaseItem))
                {
                    databaseItem = item.Adapt(databaseItem);
                    db.EducationTypes.Update(databaseItem);
                }
            }

            foreach (var item in newItems)
            {
                var databaseItem = item.Adapt<EducationType>();
                db.EducationTypes.Add(databaseItem);
            }

            var cnt = await db.SaveChangesAsync();

            return cnt;
        }        

    }
}
