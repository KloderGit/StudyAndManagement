using SaM.DataBases.EntityFramework;
using SaM.Services.Repository1C;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.UpdateEntity
{
    public class CommonUpdateEntity<T, U> : IUpdateEntity
    {
        public IUnitOfWorkEF database;
        public IUnitOfWork1C service;

        public CommonUpdateEntity()
        {
            database = new DataManagerEF();
            service = new DataManager1C();
        }


        

        public bool UpdateFromService()
        {



            return true;
        }
        
    }
}
