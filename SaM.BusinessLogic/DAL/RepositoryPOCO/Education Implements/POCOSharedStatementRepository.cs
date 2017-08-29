using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOSharedStatementRepository : ImplementRepositoryPOCO<SharedStatementPOCO, SharedStatement>, ISharedStatementRepository<SharedStatementPOCO>
    {
        public POCOSharedStatementRepository(ICommonRepository<SharedStatement> repo) : base(repo)
        {
        }
    }
}
