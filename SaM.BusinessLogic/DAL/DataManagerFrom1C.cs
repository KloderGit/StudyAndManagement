using Mapster;
using SaM.Common.DTO;
using SaM.Services.Repository1C;
using System.Collections.Generic;

namespace SaM.BusinessLogic.DAL
{
    public class DataManagerFrom1C
    {
        IDataManager1C datamanager;

        public DataManagerFrom1C()
        {
            datamanager = new DataManager1C();
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {

            var query = datamanager.Categories.GetAll().Adapt<IEnumerable<CategoryDTO>>();

            return query;
        }

        public IEnumerable<CertificationDTO> GetCertifications()
        {
            var query = datamanager.Certifications.GetAll().Adapt<IEnumerable<CertificationDTO>>();

            return query;
        }

        public IEnumerable<EducationTypeDTO> GetEducationTypes()
        {
            var query = datamanager.EducationTypes.GetAll().Adapt<IEnumerable<EducationTypeDTO>>();

            return query;
        }
    }
}
