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
using System.Collections;

namespace SaM.BusinessLogic.Facades.Education
{
    public class ProgramFacade : IFacade<EducationProgram>, IServiceFacade<EducationProgramService>
    {
        ApplicationContext db;
        DataManager1C service;

        public ProgramFacade()
        {
            db = new ApplicationContext();
            service = new DataManager1C();
        }

        public ProgramFacade(ApplicationContext db)
        {
            this.db = db;
            service = new DataManager1C();
        }

        public async Task<IEnumerable<EducationProgram>> Get()
        {
            return await db.EducationPrograms.ToListAsync();
        }

        public async Task<EducationProgram> Get(Guid guid)
        {
            return await db.EducationPrograms.FirstOrDefaultAsync(sI => sI.Guid == guid);
        }

        public async Task<IEnumerable<EducationProgramService>> GetFromService()
        {
            var query = await service.EducationPrograms.GetList();
            return query.Adapt<IEnumerable<EducationProgramService>>();
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

        public async Task<int> Add(EducationProgram item)
        {
            var databaseItem = item.Adapt<EducationProgram>();
            db.EducationPrograms.Add(databaseItem);

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Add(IEnumerable<EducationProgram> items)
        {
            foreach (var item in items)
            {
                var databaseItem = item.Adapt<EducationProgram>();
                db.EducationPrograms.Add(databaseItem);
            }

            var count = await db.SaveChangesAsync();
            return count;
        }

        private async void ToSave(EducationProgram dbItem, EducationProgram updItem)
        {
            var databaseItem = updItem.Adapt(await Get(updItem.Guid));
            db.EducationPrograms.Update(databaseItem);
        }

        public async Task<int> Update(EducationProgram item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(EducationProgramService item)
        {
            var databaseItem = Get(item.Guid).Result;

            if (databaseItem != null && !item.Equals(databaseItem))
            {
                ToSave(databaseItem, item.Adapt<EducationProgram>());
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<EducationProgram> items)
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

        public async Task<int> Update(IEnumerable<EducationProgramService> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<EducationProgramService>(new GuidComparer());

            var updateItems = serviceItems.Intersect(dbItems, new GuidComparer());

            var newItems = serviceItems.Except(updateItems, new GuidComparer());

            var count = 0;

            foreach (var item in updateItems.Cast<EducationProgramService>())
            {
                count += await Update(item);
            }

            foreach (var item in newItems.Cast<EducationProgramService>())
            {
                count += await Add(item.Adapt<EducationProgram>());
            }

            return count;
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
