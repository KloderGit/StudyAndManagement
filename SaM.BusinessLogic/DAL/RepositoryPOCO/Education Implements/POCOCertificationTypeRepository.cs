using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOCertificationTypeRepository : ImplementRepositoryPOCO<CertificationTypePOCO, CertificationType>, ICertificationTypeRepository<CertificationTypePOCO>
    {
        public POCOCertificationTypeRepository(ICommonRepository<CertificationType> repo) : base(repo)
        {
        }
    }
}
