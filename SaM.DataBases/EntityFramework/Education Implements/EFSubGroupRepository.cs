using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFSubGroupRepository : ImplementRepositoryEntityFramework<SubGroup>, ISubGroupRepository<SubGroup>
    {
        public EFSubGroupRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
