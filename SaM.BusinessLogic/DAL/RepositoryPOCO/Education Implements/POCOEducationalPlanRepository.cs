using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOEducationalPlanRepository : ImplementRepositoryPOCO<EducationalPlanPOCO, EducationalPlan>, IEducationalPlanRepository<EducationalPlanPOCO>
    {
        public POCOEducationalPlanRepository(ICommonRepository<EducationalPlan> repo) : base(repo)
        {
        }
    }
}
