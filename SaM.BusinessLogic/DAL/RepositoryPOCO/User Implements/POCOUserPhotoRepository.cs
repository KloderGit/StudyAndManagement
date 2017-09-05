using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.User;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserPhotoRepository : ImplementRepositoryPOCO<UserPhotoPOCO, UserPhoto>, IUserPhotoRepository<UserPhotoPOCO>
    {
        public POCOUserPhotoRepository(ICommonRepository<UserPhoto> repo) : base(repo)
        {
        }
    }
}
