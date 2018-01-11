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
    public class CertificationTypeFacade : IEducationFacade<CertificationType>
    {
        ApplicationContext db;
        DataManager1C service;

        public CertificationTypeFacade()
        {
            db = new ApplicationContext();
            service = new DataManager1C();
        }

        public CertificationTypeFacade(ApplicationContext db)
        {
            this.db = db;
            service = new DataManager1C();
        }

        public async Task<IEnumerable<CertificationType>> Get()
        {
            return await db.CertificationTypes.ToListAsync();
        }

        public async Task<IEnumerable<CertificationTypeDTO>> GetDTO()
        {
            var query = await Get();
            return query.Adapt<IEnumerable<CertificationTypeDTO>>();
        }

        public async Task<IEnumerable<CertificationType>> GetFromService()
        {
            var query = await service.EducationPrograms.GetList();

            var types = query.SelectMany(ii => ii.listOfSubjects
                                                 .SelectMany(kk => kk.Attestation.SpisokVariantAttestation)
                                                 .Where(iii => iii.GUIDViewAttestation != ""))
                             .Adapt<IEnumerable<CertificationType>>()
                             .Distinct<CertificationType>(new GuidComparer());


            return types;
        }

        public async Task<int> Remove(Guid guid)
        {
            var elem = db.CertificationTypes.FirstOrDefault(el => el.Guid == guid);

            if (elem == null) { new Exception(" Элемент Не найден в БД "); }

            db.CertificationTypes.Remove(elem);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Remove(IEnumerable<Guid> guids)
        {
            var toRemove = new List<CertificationType>();

            foreach (var item in guids)
            {
                var elem = db.CertificationTypes.FirstOrDefault(el => el.Guid == item);

                if (elem != null) { toRemove.Add(elem); }
            }

            if (toRemove.Count == 0) { new Exception(" Элементы Не найдены в БД "); }

            db.CertificationTypes.RemoveRange(toRemove);

            return await db.SaveChangesAsync();
        }

        public async Task<int> Add(CertificationType item)
        {
            var databaseItem = item.Adapt<CertificationType>();
            db.CertificationTypes.Add(databaseItem);

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Add(IEnumerable<CertificationType> items)
        {
            foreach (var item in items)
            {
                var databaseItem = item.Adapt<CertificationType>();
                db.CertificationTypes.Add(databaseItem);
            }

            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(CertificationType item)
        {
            var databaseItem = db.CertificationTypes.FirstOrDefault(sI => sI.Guid == item.Guid);
            if (databaseItem != null && !item.EqualService(databaseItem))
            {
                databaseItem = item.Adapt(databaseItem);
                db.CertificationTypes.Update(databaseItem);
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> Update(IEnumerable<CertificationType> items)
        {
            foreach (var item in items)
            {
                var databaseItem = db.CertificationTypes.FirstOrDefault(sI => sI.Guid == item.Guid);

                if (databaseItem != null && !item.EqualService(databaseItem))
                {
                    databaseItem = item.Adapt(databaseItem);
                    db.CertificationTypes.Update(databaseItem);
                }
            }
            var count = await db.SaveChangesAsync();
            return count;
        }

        public async Task<int> UpdateFromService()
        {
            var dbItems = await Get();
            var serviceItems = await GetFromService();

            var updateItems = serviceItems.Intersect<CertificationType>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<CertificationType>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

        public async Task<int> UpdateFromService(IEnumerable<CertificationType> items)
        {
            var dbItems = await Get();
            var serviceItems = items.Distinct<CertificationType>(new GuidComparer());

            var updateItems = serviceItems.Intersect<CertificationType>(dbItems, new GuidComparer());
            var newItems = serviceItems.Except<CertificationType>(updateItems, new GuidComparer());

            var cnt = await Update(updateItems);
            cnt += await Add(newItems);

            return cnt;
        }

    }

}
