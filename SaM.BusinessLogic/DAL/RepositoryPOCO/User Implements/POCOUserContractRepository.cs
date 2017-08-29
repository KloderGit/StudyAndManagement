using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserContractRepository : IUserContractRepository<UserContractPOCO>
    {
        public POCOUserContractRepository()
        {
        }

        public void Add(UserContractPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserContractPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserContractPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserContractPOCO> GetAllIncludeRef(params Expression<Func<UserContractPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public UserContractPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserContractPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserContractPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
