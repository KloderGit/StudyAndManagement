using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFEducationTypeRepository : ImplementRepositoryEntityFramework<EducationType>, IEducationTypeRepository<EducationType>
    {
        public EFEducationTypeRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
