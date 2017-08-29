using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserPhotoRepository : IUserPhotoRepository<UserPhotoPOCO>
    {
        public POCOUserPhotoRepository()
        {
        }

        public void Add(UserPhotoPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserPhotoPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserPhotoPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserPhotoPOCO> GetAllIncludeRef(params Expression<Func<UserPhotoPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public UserPhotoPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserPhotoPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserPhotoPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
