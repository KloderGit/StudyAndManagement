using SaM.DataBases.EntityFramework;
using SaM.Services.Repository1C;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.UpdateEntity
{
    public class UpdateEducationPrograms
    {
        public IUnitOfWorkEF database;
        public IUnitOfWork1C service;

        public UpdateEducationPrograms()
        {
            database = new DataManagerEF();
            service = new DataManager1C();
        }



        public bool UpdateFromService()
        {
            var serviceItems = service.EducationPrograms.GetList();








            return true;
        }

    }
}