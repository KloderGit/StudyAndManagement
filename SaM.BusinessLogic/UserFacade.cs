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
using SaM.Domain.Core.User;

namespace SaM.BusinessLogic
{
    public class UserFacade : IEducationFacade<User>
    {
        ApplicationContext db;
        DataManager1C service;

        public UserFacade()
        {
            db = new ApplicationContext();
            service = new DataManager1C();
        }

        public UserFacade(ApplicationContext db)
        {
            this.db = db;
            service = new DataManager1C();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await db.Users.ToListAsync();
        }

        //public async Task<IEnumerable<UserDTO>> GetDTO()
        //{
        //    var query = await Get();
        //    return query.Adapt<IEnumerable<UserDTO>>();
        //}

        public async Task<IEnumerable<User>> GetFromService()
        {
            var query = await service.Users.GetList();
            return query.Adapt<IEnumerable<User>>();
        }

        public async Task<int> Remove(Guid guid)
        {
            var elem = db.Users.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.Users.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Remove(IEnumerable<Guid> guids)
        {
            var toRemove = new List<User>();

            foreach (var item in guids)
            {
                var elem = db.Users.FirstOrDefault(el => el.Guid == item);

                if (elem != null) { toRemove.Add(elem); }
            }

            if (toRemove.Count == 0) { new Exception(" Элементы Не найдены в БД "); }

            db.Users.RemoveRange(toRemove);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Add(User item)
        {
            var databaseItem = item.Adapt<User>();
            db.Users.Add(databaseItem);

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Add(IEnumerable<User> items)
        {
            foreach (var item in items)
            {
                var databaseItem = item.Adapt<User>();
                db.Users.Add(databaseItem);
            }

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(User item)
        {
            var databaseItem = db.Users.FirstOrDefault(sI => sI.Guid == item.Guid);
            if (databaseItem != null)
            {
                databaseItem = item.Adapt(databaseItem);
                db.Users.Update(databaseItem);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<User> items)
        {
            foreach (var item in items)
            {
                var databaseItem = db.Users.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null)
                {
                    databaseItem = item.Adapt(databaseItem);
                    db.Users.Update(databaseItem);
                }
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> UpdateFromService()
        {
            var dbItems = await Get();
            var serviceItems = await GetFromService();

            var updateItems = serviceItems.Intersect<User>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<User>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

        public async Task<int> UpdateFromService(IEnumerable<User> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<User>(new GuidComparer());

            var updateItems = serviceItems.Intersect<User>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<User>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

    }
}
