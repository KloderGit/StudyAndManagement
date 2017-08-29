using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFCertificationTypeRepository : ImplementRepositoryEntityFramework<CertificationType>, ICertificationTypeRepository<CertificationType>
    {
        public EFCertificationTypeRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
