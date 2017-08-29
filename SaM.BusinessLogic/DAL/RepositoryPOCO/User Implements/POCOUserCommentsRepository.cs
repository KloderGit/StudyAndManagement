using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOUserCommentsRepository : IUserCommentRepository<UserCommentPOCO>
    {
        public POCOUserCommentsRepository()
        {
        }

        public void Add(UserCommentPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserCommentPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserCommentPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserCommentPOCO> GetAllIncludeRef(params Expression<Func<UserCommentPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public UserCommentPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCommentPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(UserCommentPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
