using Mapster;
using SaM.Common.DTO;
using SaM.Common.Infrastructure.Mapster;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces;
using SaM.Services.Repository1C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.UpdateEntity
{
    public class CommonUpdateEntity<TypeService, TypeDTO, TypeDataBase> : IUpdateEntity
        where TypeDataBase : ISharedField
    {
        public IUnitOfWorkEF database;
        public IUnitOfWork1C service;

        public CommonUpdateEntity()
        {
            database = new DataManagerEF();
            service = new DataManager1C();
        }

        /// <summary>
        /// Обновление всех существующих T в БД
        /// </summary>
        /// <returns></returns>
        public bool UpdateFromService()
        {

            var serviceItems = service.Repository<TypeService>().GetList().Adapt<IEnumerable<TypeDTO>>();
            if (serviceItems.Count() == 0) { return false; }

            var query = database.Repository<TypeDataBase>().GetList();

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

            return true;
        }

    }
}
