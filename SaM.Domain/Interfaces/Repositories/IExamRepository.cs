using SaM.Domain.Core.Education;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface IExamRepository<T> : ICommonRepository<T> where T : class
    {
    }
}
