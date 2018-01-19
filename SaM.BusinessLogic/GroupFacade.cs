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

namespace SaM.BusinessLogic
{
    public class GroupFacade : IEducationFacade<Group>
    {
        ApplicationContext db;
        DataManager1C service;

        public GroupFacade()
        {
            db = new ApplicationContext();
            service = new DataManager1C();
        }

        public GroupFacade(ApplicationContext db)
        {
            this.db = db;
            service = new DataManager1C();
        }

        public async Task<IEnumerable<Group>> Get()
        {
            return await db.Groups.ToListAsync();
        }

        public async Task<IEnumerable<GroupDTO>> GetDTO()
        {
            var query = await Get();
            return query.Adapt<IEnumerable<GroupDTO>>();
        }

        public async Task<IEnumerable<Group>> GetFromService()
        {
            var query = await service.Groups.GetList();
            return query.Adapt<IEnumerable<Group>>();
        }

        public async Task<int> Remove(Guid guid)
        {
            var elem = db.Groups.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.Groups.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Remove(IEnumerable<Guid> guids)
        {
            var toRemove = new List<Group>();

            foreach (var item in guids)
            {
                var elem = db.Groups.FirstOrDefault(el => el.Guid == item);

                if (elem != null) { toRemove.Add(elem); }
            }

            if (toRemove.Count == 0) { new Exception(" Элементы Не найдены в БД "); }

            db.Groups.RemoveRange(toRemove);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Add(Group item)
        {
            var databaseItem = item.Adapt<Group>();
            db.Groups.Add(databaseItem);

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Add(IEnumerable<Group> items)
        {
            foreach (var item in items)
            {
                var databaseItem = item.Adapt<Group>();
                db.Groups.Add(databaseItem);
            }

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(Group item)
        {
            var databaseItem = db.Groups.FirstOrDefault(sI => sI.Guid == item.Guid);
            //if (databaseItem != null && !item.EqualService(databaseItem))
            //{
            //    databaseItem = item.Adapt(databaseItem);
            //    db.Groups.Update(databaseItem);
            //}
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<Group> items)
        {
            foreach (var item in items)
            {
                var databaseItem = db.Groups.FirstOrDefault(sI => sI.Guid == item.Guid);

                //if (databaseItem != null && !item.EqualService(databaseItem))
                //{
                //    databaseItem = item.Adapt(databaseItem);
                //    db.Groups.Update(databaseItem);
                //}
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> UpdateFromService()
        {
            var dbItems = await Get();
            var serviceItems = await GetFromService();

            var updateItems = serviceItems.Intersect<Group>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<Group>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

        public async Task<int> UpdateFromService(IEnumerable<Group> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<Group>(new GuidComparer());

            var updateItems = serviceItems.Intersect<Group>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<Group>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

    }
}
