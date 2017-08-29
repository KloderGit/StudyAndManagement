using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFStatementRepository : ImplementRepositoryEntityFramework<Statement>, IStatementRepository<Statement>
    {
        public EFStatementRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
