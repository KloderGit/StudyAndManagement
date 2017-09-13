using SaM.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace SaM.DataBases.EntityFramework
{
    public class CommonImplementEFRepository<T> : IRepository<T> where T : class
    {
        protected ApplicationContext db;
        protected DbSet<T> table;

        public CommonImplementEFRepository(ApplicationContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }


        public virtual void Add(T item)
        {
            table.Add(item);
        }

        public virtual IQueryable<T> GetList()
        {
            return table;
        }

        public virtual T GetById(int id)
        {
            return table.Find(id);
        }

        public virtual void Update(T item)
        {
            table.Update(item);
        }

        public virtual void Delete(int id)
        {
            Delete(GetById(id));
        }

        public virtual void Delete(T item)
        {
            table.Remove(item);
        }

        //public virtual IEnumerable<T> GetLocal()
        //{
        //    return table.Local;
        //}

        //public IQueryable<T> GetAllIncludeRef(params Expression<Func<T, object>>[] properties)
        //{
        //    var result = table as IQueryable<T>;

        //    if (properties != null)
        //    {
        //        result = properties.Aggregate(result, (current, include) => current.Include(include));
        //    }
        //    return result;
        //}
    }
}
