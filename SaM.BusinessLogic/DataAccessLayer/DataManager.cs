using SaM.DataBases.EntityFramework;
using SaM.DataBases.Interfaces;
using SaM.Services.Repository1C;

namespace SaM.BusinessLogic.DataAccessLayer
{
    public class DataManager
    {
        public IUnitOfWorkEF datamanagerEF;
        public IUnitOfWork1C datamanager1C;

        public DataManager()
        {
            datamanagerEF = new DataManagerEF();
            datamanager1C = new DataManager1C();
        }
    }
}