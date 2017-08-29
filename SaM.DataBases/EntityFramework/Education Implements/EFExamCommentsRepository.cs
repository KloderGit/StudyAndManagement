using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFExamCommentsRepository : ImplementRepositoryEntityFramework<ExamComment>, IExamCommentRepository<ExamComment>
    {
        public EFExamCommentsRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
