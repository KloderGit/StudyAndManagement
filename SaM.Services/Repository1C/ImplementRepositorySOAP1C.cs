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
        public GetAllDelegate datamanager;

        protected abstract Task<IEnumerable<T>> GetAllAsync();  // Для переопределения метода-источника выборки в наследниках

        public ImplementRepositorySOAP1C()
        {
            datamanager = new GetAllDelegate(GetAllAsync);
        }


        public IQueryable<T> GetList()
        {
            var ttt = datamanager();
            return ttt.Result.AsQueryable();
        }
    }
}
