using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOSubjectRepository : ImplementRepositoryPOCO<SubjectPOCO, Subject>, ISubjectRepository<SubjectPOCO>
    {
        public POCOSubjectRepository(ICommonRepository<Subject> repo) : base(repo)
        {

        }
    }
}
