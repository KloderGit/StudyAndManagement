using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFExamRepository : ImplementRepositoryEntityFramework<Exam>, IExamRepository<Exam>
    {
        public EFExamRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
