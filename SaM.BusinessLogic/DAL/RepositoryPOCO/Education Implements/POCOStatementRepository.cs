using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOStatementRepository : IStatementRepository<StatementPOCO>
    {
        public POCOStatementRepository()
        {
        }

        public void Add(StatementPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(StatementPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<StatementPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<StatementPOCO> GetAllIncludeRef(params Expression<Func<StatementPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public StatementPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatementPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(StatementPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
