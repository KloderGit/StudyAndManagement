using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOExamCommentsRepository : IExamCommentRepository<ExamCommentPOCO>
    {
        public POCOExamCommentsRepository()
        {
        }

        public void Add(ExamCommentPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(ExamCommentPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ExamCommentPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ExamCommentPOCO> GetAllIncludeRef(params Expression<Func<ExamCommentPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public ExamCommentPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExamCommentPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ExamCommentPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
