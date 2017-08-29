using SaM.Domain.Core.User;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface IUserProfileRepository<T> : ICommonRepository<T> where T: class
    {
    }
}
