using SaM.Domain.Core.User;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface IUserRepository<T> : ICommonRepository<T> where T: class
    {
    }
}