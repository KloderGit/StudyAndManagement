using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOEducationTypeRepository : ImplementRepositoryPOCO<EducationTypePOCO, EducationType>, IEducationTypeRepository<EducationTypePOCO>
    {
        public POCOEducationTypeRepository(ICommonRepository<EducationType> repo) : base(repo)
        {
        }
    }
}
