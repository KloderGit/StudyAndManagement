using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BusinessLogic.Interfaces
{
    public interface IFacade<T>
    {
        Task<IEnumerable<T>> Get();

        Task<T> Get(Guid guid);

        Task<int> Remove(Guid guid);

        Task<int> Remove(IEnumerable<Guid> guids);

        Task<int> Add(T item);

        Task<int> Add(IEnumerable<T> items);

        Task<int> Update(T item);

        Task<int> Update(IEnumerable<T> items);
    }

    public interface IServiceFacade<Y>
    {
        Task<IEnumerable<Y>> GetFromService();

        Task<int> Update(Y item);

        Task<int> Update();

        Task<int> Update(IEnumerable<Y> items);
    }
}
