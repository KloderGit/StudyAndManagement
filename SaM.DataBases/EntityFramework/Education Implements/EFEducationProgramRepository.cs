using Microsoft.EntityFrameworkCore;
using System.Linq;
using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFEducationProgramRepository : ImplementRepositoryEntityFramework<EducationProgram>, IEducationProgramRepository<EducationProgram>
    {
        public EFEducationProgramRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
