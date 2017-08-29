using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOSubjectRepository : ImplementRepositoryPOCO<SubjectPOCO, Subject>, ISubjectRepository<SubjectPOCO>
    {
        public POCOSubjectRepository(ICommonRepository<Subject> repo) : base(repo)
        {

        }
    }
}
