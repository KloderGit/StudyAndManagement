using SaM.Domain.Core.User;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFUserCommentsRepository : ImplementRepositoryEntityFramework<UserComment>, IUserCommentRepository<UserComment>
    {
        public EFUserCommentsRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
