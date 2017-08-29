using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserProfileRepository : IUserProfileRepository<UserProfilePOCO>
    {
        public POCOUserProfileRepository()
        {
        }

        public void Add(UserProfilePOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserProfilePOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserProfilePOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserProfilePOCO> GetAllIncludeRef(params Expression<Func<UserProfilePOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public UserProfilePOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserProfilePOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserProfilePOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
