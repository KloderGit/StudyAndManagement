using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserCardRepository : IUserCardRepository<UserCardPOCO>
    {
        public POCOUserCardRepository()
        {
        }

        public void Add(UserCardPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserCardPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserCardPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserCardPOCO> GetAllIncludeRef(params Expression<Func<UserCardPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public UserCardPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCardPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserCardPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
