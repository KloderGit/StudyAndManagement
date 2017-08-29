using SaM.Domain.Core.User;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface IUserPhotoRepository<T> : ICommonRepository<T> where T : class
    {
    }
}
