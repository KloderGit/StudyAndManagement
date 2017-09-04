using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOEducationalPlanRepository : ImplementRepositoryPOCO<EducationalPlanPOCO, EducationalPlan>, IEducationalPlanRepository<EducationalPlanPOCO>
    {
        public POCOEducationalPlanRepository(ICommonRepository<EducationalPlan> repo) : base(repo)
        {
        }
    }
}
