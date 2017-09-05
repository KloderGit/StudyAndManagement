using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOEducationProgramRepository : ImplementRepositoryPOCO<EducationProgramPOCO, EducationProgram>, IEducationProgramRepository<EducationProgramPOCO>
    {
        public POCOEducationProgramRepository(ICommonRepository<EducationProgram> repo) : base(repo)
        {
        }
    }
}
