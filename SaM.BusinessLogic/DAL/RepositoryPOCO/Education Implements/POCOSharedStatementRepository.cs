using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOSharedStatementRepository : ISharedStatementRepository<SharedStatementPOCO>
    {
        IDataManager datamanager;

        public POCOSharedStatementRepository(IDataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public void Add(SharedStatementPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(SharedStatementPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SharedStatementPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<SharedStatementPOCO> GetAllIncludeRef(params Expression<Func<SharedStatementPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public SharedStatementPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SharedStatementPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(SharedStatementPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
