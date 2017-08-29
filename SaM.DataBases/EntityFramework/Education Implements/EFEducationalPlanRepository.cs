using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFEducationalPlanRepository : ImplementRepositoryEntityFramework<EducationalPlan>, IEducationalPlanRepository<EducationalPlan>
    {
        public EFEducationalPlanRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
