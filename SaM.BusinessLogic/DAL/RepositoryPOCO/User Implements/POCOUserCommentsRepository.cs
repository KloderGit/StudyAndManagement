using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.User;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserCommentsRepository : ImplementRepositoryPOCO<UserCommentPOCO, UserComment>, IUserCommentRepository<UserCommentPOCO>
    {
        public POCOUserCommentsRepository(ICommonRepository<UserComment> repo) : base(repo)
        {
        }
    }
}
