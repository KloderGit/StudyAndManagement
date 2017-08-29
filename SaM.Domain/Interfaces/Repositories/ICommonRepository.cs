using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface ICommonRepository<T>
            where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id); 
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        void Delete(T item);
        void Save();

        /// <summary>
        /// Загрузка зависимостей для сущности. Приминает лямбды с именами свойств ex.: ( с => c.Program, c => c.Category, ... )
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        IQueryable<T> GetAllIncludeRef(params Expression<Func<T, object>>[] properties);

        IEnumerable<T> GetLocal();
    }
}
