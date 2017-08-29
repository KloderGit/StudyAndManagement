using SaM.Domain.Core.Education;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository<T> : ICommonRepository<T> where T : class
    {
    }
}
