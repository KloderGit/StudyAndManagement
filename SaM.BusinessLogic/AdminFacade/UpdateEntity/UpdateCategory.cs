using Mapster;
using SaM.Common.DTO;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using System.Collections.Generic;
using System.Linq;

namespace SaM.BusinessLogic.AdminFacade.UpdateEntity
{
    public class UpdateCategory
    {
        public IUnitOfWorkEF database;
        public IUnitOfWork1C service;

        public UpdateCategory()
        {
            database = new DataManagerEF();
            service = new DataManager1C();
        }

        /// <summary>
        /// Обновление всех существующих категорий
        /// </summary>
        /// <returns></returns>
        public bool UpdateFromService()
        {
            var serviceItems = service.Categories.GetList().Adapt<IEnumerable<CategoryDTO>>();
            if (serviceItems.Count() == 0) { return false; }

            IQueryable<Category> query = database.Categories.GetList();

            foreach (var item in serviceItems)
            {
                var dbItem = query.Where(c => c.Guid.ToString() == item.Guid).FirstOrDefault();

                if (dbItem != null)
                {
                    dbItem = item.Adapt<CategoryDTO, Category>(dbItem);
                    database.Categories.Update(dbItem);
                }
                else
                {
                    database.Categories.Add(item.Adapt<CategoryDTO, Category>());
                }
            }

            database.Save();

            return true;
        }

        /// <summary>
        /// Обновление категории по ее GUID / Создание категории при отсутствии
        /// </summary>
        /// <param name="guid">GUID категории для обновления</param>
        /// <returns></returns>
        public bool UpdateFromService(string guid)
        {
            var serviceItem = service.Categories.GetList().Adapt<IEnumerable<CategoryDTO>>()
                                .Where(itm => itm.Guid == guid).FirstOrDefault();
            if (serviceItem == null) { return false; }

            var databaseItem = database.Categories.GetList().Where(itm => itm.Guid.ToString() == guid)
                                .FirstOrDefault();

            if (databaseItem != null)
            {
                databaseItem = serviceItem.Adapt<CategoryDTO, Category>(databaseItem);
                database.Categories.Update(databaseItem);
            }
            else
            {
                database.Categories.Add(serviceItem.Adapt<CategoryDTO, Category>());
            }

            database.Save();

            return true;
        }


        /// <summary>
        /// Обновление списка категорий по массиву GUIDs
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public bool UpdateFromService(string[] guids)
        {
            var serviceQuery = service.Categories.GetList().Adapt<IEnumerable<CategoryDTO>>();
            var serviceItems = new List<CategoryDTO>();

            foreach (var item in serviceQuery)
            {
                if (guids.Contains(item.Guid)) {
                    serviceItems.Add(item);
                }
            }

            IQueryable<Category> query = database.Categories.GetList();

            // Подготовка запроса
            foreach (var item in guids)
            {
                query.Where(c => c.Guid.ToString() == item);
            }


            foreach (var item in serviceItems)
            {
                var dbItem = query.Where(c => c.Guid.ToString() == item.Guid).FirstOrDefault();

                if (dbItem != null)
                {
                    dbItem = item.Adapt<CategoryDTO, Category>(dbItem);
                    database.Categories.Update(dbItem);
                }
                else
                {
                    database.Categories.Add(item.Adapt<CategoryDTO, Category>());
                }
            }

            database.Save();

            return true;
        }
    }
}
