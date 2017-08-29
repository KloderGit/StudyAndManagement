using SaM.Domain.Core.User;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    class EFUserLocationRepository : ImplementRepositoryEntityFramework<UserLocation>, IUserLocationRepository<UserLocation>
    {
        public EFUserLocationRepository(ApplicationContext db) : base(db)
        {
        }
    }
}
