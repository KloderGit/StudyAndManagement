using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.User;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserRepository : ImplementRepositoryPOCO<UserPOCO, User>, IUserRepository<UserPOCO>
    {
        public POCOUserRepository(ICommonRepository<User> repo) : base(repo)
        {
        }
    }
}
