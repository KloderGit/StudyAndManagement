using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.User;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserCardRepository : ImplementRepositoryPOCO<UserCardPOCO, UserCard>, IUserCardRepository<UserCardPOCO>
    {
        public POCOUserCardRepository(ICommonRepository<UserCard> repo) : base(repo)
        {
        }
    }
}
