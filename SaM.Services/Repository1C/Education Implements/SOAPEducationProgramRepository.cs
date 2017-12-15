using SaM.Domain.Interfaces.Repositories;
using SoapService1full;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SaM.Services.Repository1C
{
    public class SOAPEducationProgramRepository
    {
        ПФ_ПорталДПОPortTypeClient service;

        public SOAPEducationProgramRepository(ПФ_ПорталДПОPortTypeClient source)
        {
            service = source;
        }

        public async Task<ProgramEdu> GetEntity(dynamic key)
        {
            var itemKey = (string)key;
            return await GetProgramAsync(itemKey);
        }

        /// <summary>
        /// Получить все программы
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<ProgramEdu>> GetList()
        {
            var query = await GetAllAsync(new DateTime(2006, 1, 1), DateTime.Today);
            return query.AsQueryable();
        }

        /// <summary>
        /// Получить программы за период
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<ProgramEdu>> GetList(DateTime startDate, DateTime endDate)
        {
            var query = await GetAllAsync(startDate, endDate);
            return query.AsQueryable();
        }

        protected async Task<IEnumerable<ProgramEdu>> GetAllAsync(DateTime startDate, DateTime endDate)
        {
            var query = await service.ПолучитьИзмененныеДанныеОПрограммахДПОЗаПериодAsync(startDate.Date, endDate.Date);
            return query.@return as IEnumerable<ProgramEdu>;
        }

        protected async Task<ProgramEdu> GetProgramAsync( string guid )
        {
            var query = await service.ПолучитьДанныеОПрограммеAsync(guid);
            return query;
        }
    }
}
