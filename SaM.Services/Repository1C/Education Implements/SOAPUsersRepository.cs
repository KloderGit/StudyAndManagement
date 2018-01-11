using SaM.Domain.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using SoapService1full;
using System;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPUsersRepository 
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPUsersRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        public async Task<ДанныеПоФизЛицу> GetEntity(dynamic key)
        {

            var itemKey = (string)key;
            var query = await service.ПолучитьДанныеОФЛAsync(key);

            return query.@return as ДанныеПоФизЛицу;
        }

        public async Task<IQueryable<ДанныеПоФизЛицу>> GetList()
        {
            return await GetList(new DateTime(2006, 1, 1), DateTime.Today);
        }

        /// <summary>
        /// Получить пользователей за период
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<ДанныеПоФизЛицу>> GetList(DateTime startDate, DateTime endDate)
        {
            var result = await GetAllAsync(startDate, endDate);
            return result.AsQueryable();
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
