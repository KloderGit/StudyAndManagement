using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOStatementRepository : ImplementRepositoryPOCO<StatementPOCO, Statement>, IStatementRepository<StatementPOCO>
    {
        public POCOStatementRepository(ICommonRepository<Statement> repo) : base(repo)
        {

        }
    }
}
