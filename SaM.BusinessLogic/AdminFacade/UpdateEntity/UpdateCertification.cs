using Mapster;
using SaM.Common.DTO;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.UpdateEntity
{
    public class UpdateCertification
    {
        public IUnitOfWorkEF database;
        public IUnitOfWork1C service;

        public UpdateCertification()
        {
            database = new DataManagerEF();
            service = new DataManager1C();
        }

        /// <summary>
        /// Обновление всех существующих видов сетрификации [ Экзамен \ Зачет ]
        /// </summary>
        /// <returns></returns>
        public bool UpdateFromService()
        {
            var serviceItems = service.Certifications.GetList().Adapt<IEnumerable<CertificationDTO>>();
            if (serviceItems.Count() == 0) { return false; }

            var query = database.Certifications.GetList();

            foreach (var item in serviceItems)
            {
                var dbItem = query.Where(c => c.Guid.ToString() == item.Guid).FirstOrDefault();

                if (dbItem != null)
                {
                    dbItem = item.Adapt<CertificationDTO, Certification>(dbItem);
                    database.Certifications.Update(dbItem);
                }
                else
                {
                    database.Certifications.Add(item.Adapt<CertificationDTO, Certification>());
                }
            }

            database.Save();

            return true;
        }

        /// <summary>
        /// Обновление вида сетрификации [ Экзамен \ Зачет ] по ее GUID / Создание при отсутствии
        /// </summary>
        /// <param name="guid">GUID вида сетрификации для обновления</param>
        /// <returns></returns>
        public bool UpdateFromService(string guid)
        {
            var serviceItem = service.Certifications.GetList().Adapt<IEnumerable<CertificationDTO>>()
                                .Where(itm => itm.Guid == guid).FirstOrDefault();
            if (serviceItem == null) { return false; }

            var databaseItem = database.Certifications.GetList().Where(itm => itm.Guid.ToString() == guid)
                                .FirstOrDefault();

            if (databaseItem != null)
            {
                databaseItem = serviceItem.Adapt<CertificationDTO, Certification>(databaseItem);
                database.Certifications.Update(databaseItem);
            }
            else
            {
                database.Certifications.Add(serviceItem.Adapt<CertificationDTO, Certification>());
            }

            database.Save();

            return true;
        }


        /// <summary>
        /// Обновление списка видов сетрификации [ Экзамен \ Зачет ] по массиву GUIDs
        /// </summary>
        /// <param name="guids"></param>
        /// <returns></returns>
        public bool UpdateFromService(string[] guids)
        {
            var serviceItems = service.Certifications.GetList().Adapt<IEnumerable<CertificationDTO>>();

            var query = database.Certifications.GetList();

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
                    dbItem = serviceItem.Adapt<CertificationDTO, Certification>(dbItem);
                    database.Certifications.Update(dbItem);
                }
                else
                {
                    database.Certifications.Add(serviceItem.Adapt<CertificationDTO, Certification>());
                }
            }

            database.Save();

            return true;
        }
    }
}
