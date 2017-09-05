using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.User;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserCardRepository : ImplementRepositoryPOCO<UserCardPOCO, UserCard>, IUserCardRepository<UserCardPOCO>
    {
        public POCOUserCardRepository(ICommonRepository<UserCard> repo) : base(repo)
        {
        }
    }
}
