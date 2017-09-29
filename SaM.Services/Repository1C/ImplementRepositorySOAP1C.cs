using SaM.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.Services.Repository1C
{
    // Убрать этот класс как нибудь потом.

    public abstract class ImplementRepositorySOAP1C<T> : ICommonRepository<T>
            where T : class
    {

        public delegate Task<IEnumerable<T>> GetAllDelegate();
        public GetAllDelegate source;

        protected abstract Task<IEnumerable<T>> GetAllAsync();  // Для переопределения метода-источника выборки в наследниках

        public ImplementRepositorySOAP1C()
        {
            source = new GetAllDelegate(GetAllAsync);
        }

        public T GetEntity(dynamic key)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<T> GetList()
        {
            var ttt = source();
            return ttt.Result.AsQueryable();
        }
    }
}
