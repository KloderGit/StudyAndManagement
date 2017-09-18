using Mapster;
using SaM.Common.DTO;
using SaM.Common.Infrastructure.Mapster;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SaM.BusinessLogic
{
    public class AdminFacade
    {
        public IUnitOfWorkEF database;
        public IUnitOfWork1C service;

        public AdminFacade()
        {
            database = new DataManagerEF();
            service = new DataManager1C();

            Assembly assem = typeof(Config1CtoDTO).GetTypeInfo().Assembly;
            TypeAdapterConfig.GlobalSettings.Scan(assem);
        }

        public IEnumerable<CategoryDTO> UpdateAvailableCategoriesFromService() {

            var serviceItems = service.Categories.GetList().Adapt<IEnumerable<CategoryDTO>>();

            IQueryable<Category> query = database.Categories.GetList();

            // Подготовка запроса
            foreach (var item in serviceItems)
            {
                query.Where(c => c.Guid.ToString() == item.Guid);
            }

            foreach (var item in query)
            {
                var serviceItem = serviceItems.Where(c => c.Guid == item.Guid.ToString()).First();
                var databaseItem = serviceItem.Adapt<CategoryDTO, Category>(item);

                database.Categories.Update(databaseItem);
            }

            database.Save();

            return query.Adapt<IEnumerable<CategoryDTO>>();
        }

        public IEnumerable<CategoryDTO> UpdateAllCategoriesFromService()
        {

            var serviceItems = service.Categories.GetList().Adapt<IEnumerable<CategoryDTO>>();

            IQueryable<Category> query = database.Categories.GetList();

            foreach (var item in serviceItems)
            {
                var databaseItem = query.FirstOrDefault(itm => itm.Guid.ToString() == item.Guid);

                if (databaseItem != null)
                {
                    databaseItem = item.Adapt<CategoryDTO, Category>(databaseItem);
                    database.Categories.Update(databaseItem);
                }
                else
                {
                    database.Categories.Add(item.Adapt<CategoryDTO, Category>());
                }               
            }

            database.Save();

            return database.Categories.GetList().Adapt<IEnumerable<CategoryDTO>>();
        }

    }
}
