using SaM.Domain.Core.User;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public class EFUserPhotoRepository : ImplementRepositoryEntityFramework<UserPhoto>, IUserPhotoRepository<UserPhoto>
    {
        public EFUserPhotoRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
