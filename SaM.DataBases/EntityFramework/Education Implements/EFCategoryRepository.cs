using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFCategoryRepository: ImplementRepositoryEntityFramework<Category>, ICategoryRepository<Category>
    {
        public EFCategoryRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
