using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOSubjectRepository : ISubjectRepository<SubjectPOCO>
    {
        IDataManager datamanager;

        public POCOSubjectRepository(IDataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public void Add(SubjectPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubjectPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubjectPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<SubjectPOCO> GetAllIncludeRef(params Expression<Func<SubjectPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public SubjectPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubjectPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(SubjectPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
