using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOEducationTypeRepository : IEducationTypeRepository<EducationTypePOCO>
    {
        IDataManager datamanager;

        public POCOEducationTypeRepository(IDataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public void Add(EducationTypePOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(EducationTypePOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EducationTypePOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<EducationTypePOCO> GetAllIncludeRef(params Expression<Func<EducationTypePOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public EducationTypePOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EducationTypePOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(EducationTypePOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
