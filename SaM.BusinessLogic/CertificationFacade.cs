using Mapster;
using Microsoft.EntityFrameworkCore;
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
        public class CertificationFacade
        {
            ApplicationContext db = new ApplicationContext();
            DataManager1C service = new DataManager1C();

            public async Task<IEnumerable<Certification>> GetPOCO()
            {
                return await db.Certifications.ToListAsync();
            }

            public async Task<IEnumerable<CertificationDTO>> GetDTO()
            {
                var query = await GetPOCO();
                return query.Adapt<IEnumerable<CertificationDTO>>();
            }

            public async Task<IEnumerable<Certification>> GetFromService()
            {
                var query = await service.Certifications.GetList();
                return query.Adapt<IEnumerable<Certification>>();
            }

            public async Task<int> RemoveItem(Guid guid)
            {
                var elem = db.Certifications.FirstOrDefault(el => el.Guid == guid);

                if (elem == null) { new Exception(" Элемент Не найден в БД "); }

                db.Certifications.Remove(elem);

                return await db.SaveChangesAsync();
            }

            public async Task<int> RemoveItems(IEnumerable<Guid> guids)
            {
                var toRemove = new List<Certification>();

                foreach (var item in guids)
                {
                    var elem = db.Certifications.FirstOrDefault(el => el.Guid == item);

                    if (elem != null) { toRemove.Add(elem); }
                }

                if (toRemove.Count == 0) { new Exception(" Элементы Не найдены в БД "); }

                db.Certifications.RemoveRange(toRemove);

                return await db.SaveChangesAsync();
            }

            public async Task<int> Update()
            {
                var dbItems = await GetPOCO();
                var serviceItems = await GetFromService();

                var updateItems = serviceItems.Intersect<Certification>(dbItems, new GuidComparer());
                var newItems = serviceItems.Except<Certification>(updateItems, new GuidComparer());

                foreach (var item in updateItems)
                {
                    var databaseItem = db.Certifications.FirstOrDefault(sI => sI.Guid == item.Guid);

                    if (databaseItem != null && !item.EqualService(databaseItem))
                    {
                        databaseItem = item.Adapt(databaseItem);
                        db.Certifications.Update(databaseItem);
                    }
                }

                foreach (var item in newItems)
                {
                    var databaseItem = item.Adapt<Certification>();
                    db.Certifications.Add(databaseItem);
                }

                var cnt = await db.SaveChangesAsync();

                return cnt;
            }
        }
    
}
