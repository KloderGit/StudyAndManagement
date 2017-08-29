using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOCertificationTypeRepository : ICertificationTypeRepository<CertificationTypePOCO>
    {
        IDataManager datamanager;

        public POCOCertificationTypeRepository(IDataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public void Add(CertificationTypePOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(CertificationTypePOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CertificationTypePOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CertificationTypePOCO> GetAllIncludeRef(params Expression<Func<CertificationTypePOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public CertificationTypePOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CertificationTypePOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(CertificationTypePOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
