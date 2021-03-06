﻿using System;
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

        IEnumerable<T> GetLocal();
    }
}
