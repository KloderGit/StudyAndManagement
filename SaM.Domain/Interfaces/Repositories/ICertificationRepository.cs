using SaM.Domain.Core.Education;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface ICertificationRepository<T> : ICommonRepository<T> where T : class
    {
    }
}
