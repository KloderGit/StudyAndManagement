using SaM.Domain.Core.User;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface IUserLocationRepository<T> : ICommonRepository<T> where T : class
    {
    }
}
