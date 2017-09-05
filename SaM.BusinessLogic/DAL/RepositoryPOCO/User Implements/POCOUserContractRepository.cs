using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.User;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserContractRepository : ImplementRepositoryPOCO<UserContractPOCO, UserContract>, IUserContractRepository<UserContractPOCO>
    {
        public POCOUserContractRepository(ICommonRepository<UserContract> repo) : base(repo)
        {
        }
    }
}
