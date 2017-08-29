using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOCategoryRepository: ICategoryRepository<CategoryPOCO>
    {
        IDataManager datamanager;

        public POCOCategoryRepository(IDataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public void Add(CategoryPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(CategoryPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CategoryPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CategoryPOCO> GetAllIncludeRef(params Expression<Func<CategoryPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public CategoryPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
