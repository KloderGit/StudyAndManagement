using SaM.Domain.Core.User;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFUserProfileRepository : ImplementRepositoryEntityFramework<UserProfile>, IUserProfileRepository<UserProfile>
    {
        public EFUserProfileRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
