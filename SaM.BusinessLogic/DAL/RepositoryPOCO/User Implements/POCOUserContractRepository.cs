using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.User;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserContractRepository : ImplementRepositoryPOCO<UserContractPOCO, UserContract>, IUserContractRepository<UserContractPOCO>
    {
        public POCOUserContractRepository(ICommonRepository<UserContract> repo) : base(repo)
        {
        }
    }
}
