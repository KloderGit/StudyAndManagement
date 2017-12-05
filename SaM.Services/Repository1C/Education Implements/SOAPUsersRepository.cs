using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;
using System;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPUsersRepository : ICommonRepository<ДанныеПоФизЛицу>
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPUsersRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        public ДанныеПоФизЛицу GetEntity(dynamic key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ДанныеПоФизЛицу> GetList()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Получить пользователей за период
        /// </summary>
        /// <returns></returns>
        public IQueryable<ДанныеПоФизЛицу> GetList(DateTime startDate, DateTime endDate)
        {
            return GetAllAsync(startDate, endDate).Result.AsQueryable();
        }

        protected async Task<IEnumerable<ДанныеПоФизЛицу>> GetAllAsync(DateTime startDate, DateTime endDate)
        {
            var query = await service.ПолучитьИзмененныеДанныеОФЛЗаПериодAsync(startDate.Date, endDate.Date);
            return query.@return as IEnumerable<ДанныеПоФизЛицу>;
        }

        protected async Task<ДанныеПоФизЛицу> GetUserAsync(string guid)
        {
            var query = await service.ПолучитьДанныеОФЛAsync(guid);
            return query;
        }
    }
}
