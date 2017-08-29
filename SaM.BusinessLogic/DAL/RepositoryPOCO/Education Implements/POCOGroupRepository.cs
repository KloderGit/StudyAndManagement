using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOGroupRepository : IGroupRepository<GroupPOCO>
    {
        public POCOGroupRepository()
        {
        }

        public void Add(GroupPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(GroupPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<GroupPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<GroupPOCO> GetAllIncludeRef(params Expression<Func<GroupPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public GroupPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(GroupPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
