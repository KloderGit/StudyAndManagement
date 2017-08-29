using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFCertificationRepository : ImplementRepositoryEntityFramework<Certification>, ICertificationRepository<Certification>
    {
        public EFCertificationRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
