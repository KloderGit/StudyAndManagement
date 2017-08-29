using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public abstract class ImplementRepositoryPOCO<T, U> : ICommonRepository<T>
        where T : class
        where U : class
    {
        protected ICommonRepository<U> repository;

        public ImplementRepositoryPOCO(ICommonRepository<U> repository)
        {
            this.repository = repository;
        }

        public virtual void Add(T item)
        {
            repository.Add(item as U);
        }

        public virtual IQueryable<T> GetAll()
        {
            return repository.GetAll() as IQueryable<T>;
        }

        public virtual T GetById(int id)
        {
            return repository.GetById(id) as T;
        }

        public virtual void Save()
        {
            repository.Save();
        }

        public virtual void Update(T item)
        {
            repository.Update(item as U);
        }

        public virtual void Delete(int id)
        {
            repository.Delete(GetById(id) as U);
        }

        public virtual void Delete(T item)
        {
            repository.Delete(item as U);
        }

        public virtual IEnumerable<T> GetLocal()
        {
            return repository.GetLocal() as IEnumerable<T>;
        }
    }
}
