using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOExamCommentsRepository : ImplementRepositoryPOCO<ExamCommentPOCO, ExamComment>, IExamCommentRepository<ExamCommentPOCO>
    {
        public POCOExamCommentsRepository(ICommonRepository<ExamComment> repo) : base(repo)
        {
        }
    }
}
