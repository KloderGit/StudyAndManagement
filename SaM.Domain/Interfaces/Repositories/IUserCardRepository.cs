using SaM.Domain.Core.User;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface IUserCardRepository<T> : ICommonRepository<T> where T : class
    {
    }
}
