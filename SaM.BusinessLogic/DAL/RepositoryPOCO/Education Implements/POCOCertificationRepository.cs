using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOCertificationRepository : ImplementRepositoryPOCO<CertificationPOCO, Certification>, ICertificationRepository<CertificationPOCO>
    {
        public POCOCertificationRepository(ICommonRepository<Certification> repo) : base(repo)
        {
        }
    }
}
