using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOExamRepository : IExamRepository<ExamPOCO>
    {
        public POCOExamRepository()
        {
        }

        public void Add(ExamPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(ExamPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ExamPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ExamPOCO> GetAllIncludeRef(params Expression<Func<ExamPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public ExamPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ExamPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
