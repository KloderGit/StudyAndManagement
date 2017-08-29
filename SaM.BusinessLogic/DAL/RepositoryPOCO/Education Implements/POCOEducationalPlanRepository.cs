using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOEducationalPlanRepository : IEducationalPlanRepository<EducationalPlanPOCO>
    {
        public POCOEducationalPlanRepository()
        {
        }

        public void Add(EducationalPlanPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(EducationalPlanPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EducationalPlanPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<EducationalPlanPOCO> GetAllIncludeRef(params Expression<Func<EducationalPlanPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public EducationalPlanPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EducationalPlanPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(EducationalPlanPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
