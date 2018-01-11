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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BusinessLogic
{
    public class ProgramFacade : IEducationFacade<EducationProgram>
    {
        ApplicationContext db = new ApplicationContext();
        DataManager1C service = new DataManager1C();

        public async Task<IEnumerable<EducationProgram>> Get()
        {
            Console.WriteLine("Чтение программ из БД");

            return await db.EducationPrograms.ToListAsync();
        }

        public async Task<IEnumerable<EducationProgramDTO>> GetDTO()
        {
            var query = await Get();
            return query.Adapt<IEnumerable<EducationProgramDTO>>();
        }

        public async Task<IEnumerable<EducationProgram>> GetFromService()
        {
            Console.WriteLine("Чтение программ из 1С");

            var query = await service.EducationPrograms.GetList();
            return query.Adapt<IEnumerable<EducationProgram>>();
        }

        public async Task<int> Add(EducationProgram item)
        {
            item.CategoryId = db.Categories.FirstOrDefault(cat => cat.Guid == item.Category.Guid)?.Id;
            item.EducationTypeId = db.EducationTypes.FirstOrDefault(edu => edu.Guid == item.EducationType.Guid)?.Id;

            var databaseItem = item.Adapt<EducationProgram>();
            db.EducationPrograms.Add(databaseItem);

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Add(IEnumerable<EducationProgram> items)
        {
            foreach (var item in items)
            {
                item.CategoryId = db.Categories.FirstOrDefault(cat => cat.Guid == item.Category.Guid)?.Id;
                item.EducationTypeId = db.EducationTypes.FirstOrDefault(edu => edu.Guid == item.EducationType.Guid)?.Id;

                var databaseItem = item.Adapt<EducationProgram>();
                db.EducationPrograms.Add(databaseItem);
            }

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Remove(Guid guid)
        {
            var elem = db.EducationPrograms.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.EducationPrograms.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Remove(IEnumerable<Guid> guids)
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

        public async Task<int> Update(EducationProgram item)
        {

            var databaseItem = db.EducationPrograms.FirstOrDefault(sI => sI.Guid == item.Guid);

            if (databaseItem != null && !item.EqualService(databaseItem))
            {
                item.CategoryId = db.Categories.FirstOrDefault(cat => cat.Guid == item.Category.Guid)?.Id;
                item.EducationTypeId = db.EducationTypes.FirstOrDefault(edu => edu.Guid == item.EducationType.Guid)?.Id;

                databaseItem = item.Adapt(databaseItem);
                db.EducationPrograms.Update(databaseItem);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<EducationProgram> items)
        {
            foreach (var item in items)
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
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> UpdateFromService()
        {
            var dbItems = await Get();
            var serviceItems = await GetFromService();

            PrepareRelations(serviceItems);

            var updateItems = serviceItems.Intersect<EducationProgram>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<EducationProgram>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

        public async Task<int> UpdateFromService(IEnumerable<EducationProgram> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<EducationProgram>(new GuidComparer());

            PrepareRelations(serviceItems);

            var updateItems = serviceItems.Intersect<EducationProgram>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<EducationProgram>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

        private void PrepareRelations(IEnumerable<EducationProgram> serviceItems)
        {
            Console.WriteLine("Получить и обновить зависимые Категории");
            var categories = serviceItems.Select(itm => itm.Category).Distinct<Category>(new GuidComparer());
            var categoriesFactory = new CategoryFacade().UpdateFromService(categories).Result;

            Console.WriteLine("Получить и обновить зависимые Типы Обучения");
            var eduType = serviceItems.Select(itm => itm.EducationType).Distinct<EducationType>(new GuidComparer());
            var eduTypeFactory = new EducationTypeFacade().Update(eduType);
        }


        private void PrepareRelations()
        {
            var properties = typeof(EducationProgram).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var toUpdate = properties?.Where(prop => prop.GetAccessors()[0].IsVirtual &&
                                                   !prop.GetAccessors()[0].IsFinal &&
                                                   !typeof(IEnumerable).IsAssignableFrom(prop.PropertyType));

            foreach (var property in toUpdate)
            {
                var name = GetFacadeName(property);

                if (name == null) return;

                var template = name.GetConstructor(new Type[] { typeof(ApplicationContext) });

                dynamic Obj = template.Invoke(new object[] { new ApplicationContext() });

                var sddee = Obj.UpdateFromService().Result;
            }
        }

        private Type GetFacadeName(PropertyInfo propInfo)
        {
            Assembly assembly = typeof(IEducationFacade).GetTypeInfo().Assembly;
            var assemblyTypes = assembly.GetTypes();

            var result = assemblyTypes.Where(t => typeof(IEducationFacade).IsAssignableFrom(t))
                                      .FirstOrDefault(it => it.GetInterfaces()
                                                              .Where(i => i.GetGenericArguments()
                                                                           .Any(el => el == propInfo.PropertyType)).Count() > 0);

            return result;
        }

    }
}
