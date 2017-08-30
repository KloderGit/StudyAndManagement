using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOCategoryRepository: ImplementRepositoryPOCO<CategoryPOCO, Category>, ICategoryRepository<CategoryPOCO>
    {
        public POCOCategoryRepository(ICommonRepository<Category> repo) : base(repo)
        {
        }
    }
}
