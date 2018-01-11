using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BusinessLogic.Interfaces
{
    public interface IEducationFacade
    { }

    public interface IEducationFacade<T> : IEducationFacade
    {
        Task<IEnumerable<T>> Get();

        Task<IEnumerable<T>> GetFromService();

        Task<int> Remove(Guid guid);

        Task<int> Remove(IEnumerable<Guid> guids);

        Task<int> Add(T item);

        Task<int> Add(IEnumerable<T> items);

        Task<int> Update(T item);

        Task<int> Update(IEnumerable<T> items);

        Task<int> UpdateFromService();

        Task<int> UpdateFromService(IEnumerable<T> items);
    }
}
