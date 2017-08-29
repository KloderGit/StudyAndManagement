using SaM.Domain.Core.User;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFUserRepository : ImplementRepositoryEntityFramework<User>, IUserRepository<User>
    {
        public EFUserRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
