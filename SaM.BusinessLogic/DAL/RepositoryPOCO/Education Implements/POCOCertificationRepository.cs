using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public class POCOCertificationRepository : ICertificationRepository<CertificationPOCO>
    {
        public POCOCertificationRepository()
        {
        }

        public void Add(CertificationPOCO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(CertificationPOCO item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CertificationPOCO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<CertificationPOCO> GetAllIncludeRef(params Expression<Func<CertificationPOCO, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        public CertificationPOCO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CertificationPOCO> GetLocal()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(CertificationPOCO item)
        {
            throw new NotImplementedException();
        }
    }
}
