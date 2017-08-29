using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFSubjectRepository : ImplementRepositoryEntityFramework<Subject>, ISubjectRepository<Subject>
    {
        public EFSubjectRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
