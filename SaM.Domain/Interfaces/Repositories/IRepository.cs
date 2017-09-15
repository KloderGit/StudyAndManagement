using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : ICommonRepository<T>
    {
        T GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        void Delete(T item);
    }
}
