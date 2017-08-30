using SaM.Domain.Interfaces.Repositories;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Core.Education;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOEducationProgramRepository : ImplementRepositoryPOCO<EducationProgramPOCO, EducationProgram>, IEducationProgramRepository<EducationProgramPOCO>
    {
        public POCOEducationProgramRepository(ICommonRepository<EducationProgram> repo) : base(repo)
        {
        }
    }
}
