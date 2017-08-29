using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFGroupRepository : ImplementRepositoryEntityFramework<Group>, IGroupRepository<Group>
    {
        public EFGroupRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
