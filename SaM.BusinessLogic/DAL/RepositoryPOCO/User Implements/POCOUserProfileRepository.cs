using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.User;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserProfileRepository : ImplementRepositoryPOCO<UserProfilePOCO, UserProfile>, IUserProfileRepository<UserProfilePOCO>
    {
        public POCOUserProfileRepository(ICommonRepository<UserProfile> repo) : base(repo)
        {
        }
    }
}
