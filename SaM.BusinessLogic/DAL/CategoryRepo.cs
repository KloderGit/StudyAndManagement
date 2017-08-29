using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessLogic.DTO;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL
{
    public class CategoryRepo : ICategoryRepository<CategoryDTO>
    {
        IDataManager datamanager = new DataManagerEntityFramework();

        public CategoryRepo(IDataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public void Add(CategoryDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(CategoryDTO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CategoryDTO> GetAllIncludeRef(params Expression<Func<CategoryDTO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public CategoryDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDTO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
