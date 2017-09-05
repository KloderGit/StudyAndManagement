using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.User;
using SaM.Common.POCO;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    class POCOUserLocationRepository : ImplementRepositoryPOCO<UserLocationPOCO, UserLocation>, IUserLocationRepository<UserLocationPOCO>
    {
        public POCOUserLocationRepository(ICommonRepository<UserLocation> repo) : base(repo)
        {
        }
    }
}
