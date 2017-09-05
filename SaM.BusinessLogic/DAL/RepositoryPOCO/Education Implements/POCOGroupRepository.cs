using SaM.Common.POCO;
using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOGroupRepository : ImplementRepositoryPOCO<GroupPOCO, Group>, IGroupRepository<GroupPOCO>
    {
        public POCOGroupRepository(ICommonRepository<Group> repo) : base(repo)
        {
        }
    }
}
