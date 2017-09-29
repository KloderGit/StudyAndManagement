using System.Linq;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface ICommonRepository<T>
    {
        IQueryable<T> GetList();
        T GetEntity(dynamic key);
    }
}