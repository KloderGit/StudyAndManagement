using SaM.Domain.Core.Education;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface IGroupRepository<T> : ICommonRepository<T> where T : class
    {
    }
}
