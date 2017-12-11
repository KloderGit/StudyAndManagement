using Mapster;
using SaM.Common.DTO;
using SaM.Common.POCO;
using SaM.DataBases.EntityFramework;
using SaM.DataBases.Interfaces;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.UpdateEntity
{
    public class UpdateEducationType
    {
        public IUnitOfWorkEF database;
        public IUnitOfWork1C service;

        public UpdateEducationType()
        {
            database = new DataManagerEF();
            service = new DataManager1C();
        }

        /// <summary>
        /// Обновление всех типов обучения [ ОЧное \ Заочное ]
        /// </summary>
        /// <returns></returns>
        public bool UpdateFromService()
        {
            var serviceItems = service.EducationTypes.GetList().Adapt<IEnumerable<EducationTypeDTO>>();
            if (serviceItems.Count() == 0) { return false; }

            var query = database.EducationTypes.GetList();

            foreach (var item in serviceItems)
            {
                var dbItem = query.Where(c => c.Guid.ToString() == item.Guid).FirstOrDefault();

                if (dbItem != null)
                {
                    dbItem = item.Adapt<EducationTypeDTO, EducationType>(dbItem);
                    database.EducationTypes.Update(dbItem);
                }
                else
                {
                    database.EducationTypes.Add(item.Adapt<EducationTypeDTO, EducationType>());
                }
            }

            database.Save();

            return true;
        }

        /// <summary>
        /// Обновление типа обучения [ ОЧное \ Заочное ] по GUID / Создание типа при отсутствии
        /// </summary>
        /// <param name="guid">GUID EducationType для обновления</param>
        /// <returns></returns>
        public bool UpdateFromService(string guid)
        {
            var serviceItem = service.EducationTypes.GetList().Adapt<IEnumerable<EducationTypeDTO>>()
                                .Where(itm => itm.Guid == guid).FirstOrDefault();
            if (serviceItem == null) { return false; }

            var databaseItem = database.EducationTypes.GetList().Where(itm => itm.Guid.ToString() == guid)
                                .FirstOrDefault();

            if (databaseItem != null)
            {
                databaseItem = serviceItem.Adapt<EducationTypeDTO, EducationType>(databaseItem);
                database.EducationTypes.Update(databaseItem);
            }
            else
            {
                database.EducationTypes.Add(serviceItem.Adapt<EducationTypeDTO, EducationType>());
            }

            database.Save();

            return true;
        }


        /// <summary>
        /// Обновление списка типов обучения [ ОЧное \ Заочное ] по массиву GUIDs
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public bool UpdateFromService(string[] guids)
        {
            var serviceItems = service.EducationTypes.GetList().Adapt<IEnumerable<EducationTypeDTO>>();

            var query = database.EducationTypes.GetList();

            // Подготовка запроса
            foreach (var item in guids)
            {
                query.Where(c => c.Guid.ToString() == item);
            }

            foreach (var guid in guids)
            {
                var dbItem = query.Where(c => c.Guid.ToString() == guid).FirstOrDefault();
                var serviceItem = serviceItems.Where(si => si.Guid == guid).FirstOrDefault();
                if (serviceItem == null) { return false; }
 
                if (dbItem != null)
                {
                        dbItem = serviceItem.Adapt<EducationTypeDTO, EducationType>(dbItem);
                        database.EducationTypes.Update(dbItem);
                }
                else
                {
                    database.EducationTypes.Add(serviceItem.Adapt<EducationTypeDTO, EducationType>());
                }
            }

            database.Save();

            return true;
        }

        public bool UpdateFromService( IEnumerable<EducationTypeDTO> items )
        {
            var databaseItems = database.EducationTypes.GetList().Where(dbIt => items.Select(i => i.Guid).Contains(dbIt.Guid.ToString()));

            foreach (var item in items)
            {
                var dbItem = databaseItems.Where(c => c.Guid.ToString() == item.Guid).FirstOrDefault();

                if (dbItem != null)
                {
                    dbItem = item.Adapt<EducationTypeDTO, EducationType>(dbItem);
                    database.EducationTypes.Update(dbItem);
                }
                else
                {
                    database.EducationTypes.Add(item.Adapt<EducationTypeDTO, EducationType>());
                }
            }

            database.Save();

            return true;
        }



    }
}
