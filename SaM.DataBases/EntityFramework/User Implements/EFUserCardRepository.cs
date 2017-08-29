using SaM.Domain.Core.User;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFUserCardRepository : ImplementRepositoryEntityFramework<UserCard>, IUserCardRepository<UserCard>
    {
        public EFUserCardRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
