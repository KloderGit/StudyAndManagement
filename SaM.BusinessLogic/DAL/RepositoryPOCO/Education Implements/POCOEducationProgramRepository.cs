using System.Linq;
using SaM.Domain.Interfaces.Repositories;
using SaM.BusinessLogic.POCO;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOEducationProgramRepository : IEducationProgramRepository<EducationProgramPOCO>
    {
        IDataManager datamanager;

        public POCOEducationProgramRepository(IDataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public void Add(EducationProgramPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(EducationProgramPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<EducationProgramPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<EducationProgramPOCO> GetAllIncludeRef(params Expression<Func<EducationProgramPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public EducationProgramPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EducationProgramPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(EducationProgramPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
