using SaM.BusinessLogic.Interfaces;
using SaM.Domain.Core.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaM.BusinessLogic.UpdateBuilders
{
    public class CategoryBuilder
    {
        IEnumerable<Category> dbItems;
        IEnumerable<Category> serviceItems;

        /// <summary>
        /// Обновление Категорий из сервиса. Первый параметр - элементы базы данныз, второй - элементы из сервиса
        /// </summary>
        /// <param name="dbItems"></param>
        /// <param name="serviceItems"></param>
        public CategoryBuilder(IEnumerable<Category> dbItems, IEnumerable<Category> serviceItems)
        {
            this.dbItems = dbItems;
            this.serviceItems = serviceItems;
        }

        IEnumerable<Category> GetExistingItems()
        {
            return serviceItems.Intersect(dbItems);
        }

        IEnumerable<Category> GetNewItems()
        {
            return GetExistingItems().Except(serviceItems);
        }
    }
}
