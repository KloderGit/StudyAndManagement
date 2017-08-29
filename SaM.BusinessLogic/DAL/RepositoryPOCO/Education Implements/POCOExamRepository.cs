using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOExamRepository : ImplementRepositoryPOCO<ExamPOCO, Exam>, IExamRepository<ExamPOCO>
    {
        public POCOExamRepository(ICommonRepository<Exam> repo) : base(repo)
        {
        }
    }
}
