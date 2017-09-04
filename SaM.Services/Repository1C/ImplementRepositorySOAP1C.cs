using SaM.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SoapService1C;
using System.Threading.Tasks;

namespace SaM.Services.Repository1C
{
    public abstract class ImplementRepositorySOAP1C<T> : ICommonRepository<T>
            where T : class
    {
        public delegate Task<IEnumerable<T>> GetAllDelegate();

        public GetAllDelegate datamanager;

        public ImplementRepositorySOAP1C()
        {
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            var ttt = datamanager();
            return ttt.Result.AsQueryable();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
