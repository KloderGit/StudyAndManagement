using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using DataBase.EntityFramework;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public abstract class ImplementRepositoryEntityFramework<T> : ICommonRepository<T>
        where T : class
    {
        protected ApplicationContext db;
        protected DbSet<T> table;

        delegate bool IsEqual(T x);

        public ImplementRepositoryEntityFramework(ApplicationContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public virtual void Add(T item)
        {
            table.Add(item);
        }

        public virtual IEnumerable<T> GetAll2()
        {
            return table;
        }

        public virtual IQueryable<T> GetAll()
        {
            return table;
        }

        public virtual T GetById(int id)
        {
            return table.Find(id);
        }

        public virtual void Save()
        {
            db.SaveChanges();
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

        public virtual IEnumerable<T> GetLocal()
        {
            return table.Local;
        }

        public IQueryable<T> GetAllIncludeRef(params Expression<Func<T, object>>[] properties)
        {
            var result = table as IQueryable<T>;

            if (properties != null)
            {
                result = properties.Aggregate( result, (current, include) => current.Include(include));
            }
            return result;
        }
    }
}
