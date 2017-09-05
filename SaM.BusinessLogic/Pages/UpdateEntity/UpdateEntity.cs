using Mapster;
using SaM.Common.DTO;
using SaM.Services.Repository1C;
using SoapService1C;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SaM.BusinessLogic.Pages.UpdateEntity
{
    public class UpdateEntity
    {
        IDataManager1C datamanager;

        public UpdateEntity()
        {
            datamanager = new DataManager1C();
        }

        public IEnumerable<CategoryDTO> GetCategories() {

            var query = datamanager.Categories.GetAll().Adapt<IEnumerable<CategoryDTO>>();

            return query;
        }

        public IEnumerable<CertificationDTO> GetCertifications()
        {
            var t = datamanager.Certifications.GetAll();
            var query = t.Adapt<IEnumerable<CertificationDTO>>();

            return query;
        }

        public IEnumerable<EducationTypeDTO> GetEducationTypes()
        {
            var t = datamanager.EducationTypes.GetAll();
            var query = t.Adapt<IEnumerable<EducationTypeDTO>>();

            return query;
        }
    }
}
