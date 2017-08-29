using SaM.Domain.Core.Education;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface ISubjectRepository<T> : ICommonRepository<T> where T : class
    {
    }
}
