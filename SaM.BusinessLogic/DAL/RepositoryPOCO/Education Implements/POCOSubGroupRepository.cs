using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOSubGroupRepository : ImplementRepositoryPOCO<SubGroupPOCO, SubGroup>, ISubGroupRepository<SubGroupPOCO>
    {
        public POCOSubGroupRepository(ICommonRepository<SubGroup> repo) : base(repo)
        {
        }
    }
}
