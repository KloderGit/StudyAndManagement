using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOSubGroupRepository : ISubGroupRepository<SubGroupPOCO>
    {
        IDataManager datamanager;

        public POCOSubGroupRepository(IDataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public void Add(SubGroupPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubGroupPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubGroupPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubGroupPOCO> GetAllIncludeRef(params Expression<Func<SubGroupPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public SubGroupPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubGroupPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(SubGroupPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
