using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.User;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserCommentsRepository : ImplementRepositoryPOCO<UserCommentPOCO, UserComment>, IUserCommentRepository<UserCommentPOCO>
    {
        public POCOUserCommentsRepository(ICommonRepository<UserComment> repo) : base(repo)
        {
        }
    }
}
