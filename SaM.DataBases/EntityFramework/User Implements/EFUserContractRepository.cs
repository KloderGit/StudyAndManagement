using SaM.Domain.Core.User;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFUserContractRepository : ImplementRepositoryEntityFramework<UserContract>, IUserContractRepository<UserContract>
    {
        public EFUserContractRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
