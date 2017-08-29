using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFSharedStatementRepository : ImplementRepositoryEntityFramework<SharedStatement>, ISharedStatementRepository<SharedStatement>
    {
        public EFSharedStatementRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
