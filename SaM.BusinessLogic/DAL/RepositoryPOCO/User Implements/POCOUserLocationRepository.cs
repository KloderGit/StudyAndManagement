using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    class POCOUserLocationRepository : IUserLocationRepository<UserLocationPOCO>
    {
        IDataManager datamanager;

        public POCOUserLocationRepository(IDataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public void Add(UserLocationPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserLocationPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserLocationPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserLocationPOCO> GetAllIncludeRef(params Expression<Func<UserLocationPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public UserLocationPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserLocationPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserLocationPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
