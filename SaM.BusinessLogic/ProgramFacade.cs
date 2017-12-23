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
    public class ProgramFacade
    {
        ApplicationContext db = new ApplicationContext();
        DataManager1C service = new DataManager1C();

        public async Task<IEnumerable<EducationProgram>> GetPOCO()
        {
            Console.WriteLine("Чтение программ из БД");

            return await db.EducationPrograms.ToListAsync(); 
        }

        public async Task<IEnumerable<EducationProgramDTO>> GetDTO()
        {
            var query = await GetPOCO();
            return query.Adapt<IEnumerable<EducationProgramDTO>>();
        }

        public async Task<IEnumerable<EducationProgram>> GetFromService()
        {
            Console.WriteLine("Чтение программ из 1С");

            var query = await service.EducationPrograms.GetList();
            return query.Adapt<IEnumerable<EducationProgram>>();
        }

        public async Task<int> RemoveItem( Guid guid )
        {
            var elem = db.EducationPrograms.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.EducationPrograms.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> RemoveItems(IEnumerable<Guid> guids)
        {
            var toRemove = new List<EducationProgram>();

            foreach (var item in guids)
            {
                var elem = db.EducationPrograms.FirstOrDefault(el => el.Guid == item);

                if (elem != null) { toRemove.Add(elem); }
            }

            if (toRemove.Count == 0) { new Exception(" Элементы Не найдены в БД "); }

            db.EducationPrograms.RemoveRange(toRemove);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Update()
        {
            var dbItems = await GetPOCO();
            var serviceItems = await GetFromService();

            Console.WriteLine("Получить и обновить зависимые Категории");
            var categories = serviceItems.Select(itm => itm.Category).Distinct<Category>(new GuidComparer());
            var categoriesFactory = new CategoryFacade().UpdateFromService(categories).Result;

            Console.WriteLine("Получить и обновить зависимые Типы Обучения");
            var eduType = serviceItems.Select(itm => itm.EducationType).Distinct<EducationType>(new GuidComparer());
            var eduTypeFactory = new EducationTypeFacade().Update(eduType);

            var updateItems = serviceItems.Intersect<EducationProgram>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<EducationProgram>(updateItems, new GuidComparer());

            Console.WriteLine("Обновление программ");
            foreach (var item in updateItems)
            {
                var databaseItem = db.EducationPrograms.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null && !item.EqualService(databaseItem))
                {
                    item.CategoryId = db.Categories.FirstOrDefault(cat => cat.Guid == item.Category.Guid)?.Id;
                    item.EducationTypeId = db.EducationTypes.FirstOrDefault(edu => edu.Guid == item.EducationType.Guid)?.Id;
                    databaseItem = item.Adapt(databaseItem);
                    db.EducationPrograms.Update(databaseItem);
                }
            }

            Console.WriteLine("Создание программ");

            foreach (var item in newItems)
            {
                item.CategoryId = db.Categories.FirstOrDefault( cat => cat.Guid == item.Category.Guid )?.Id;
                item.EducationTypeId = db.EducationTypes.FirstOrDefault( edu => edu.Guid == item.EducationType.Guid)?.Id;
                var databaseItem = item.Adapt<EducationProgram>();
                db.EducationPrograms.Add(databaseItem);
            }

            var cnt = await db.SaveChangesAsync();

            return cnt;
        }
    }
}
