using SaM.Domain.Core.User;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface IUserCommentRepository<T> : ICommonRepository<T> where T : class
    {
    }
}
