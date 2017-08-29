using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserRepository : IUserRepository<UserPOCO>
    {
        IDataManager datamanager;

        public POCOUserRepository(IDataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public void Add(UserPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserPOCO> GetAllIncludeRef(params Expression<Func<UserPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public UserPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
