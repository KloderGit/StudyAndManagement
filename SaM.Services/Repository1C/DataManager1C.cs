using SaM.Domain.Interfaces.Repositories;
using SoapService1full;
using System.Reflection;

namespace SaM.Services.Repository1C
{
    public class DataManager1C : IUnitOfWork1C
    {
        ПФ_ПорталДПОPortTypeClient soap;

        public DataManager1C()
        {
            soap = new ПФ_ПорталДПОPortTypeClient(ПФ_ПорталДПОPortTypeClient.EndpointConfiguration.ПФ_ПорталДПОSoap);
        }

        SOAPCategoryRepository CategoriesRepository;
        SOAPCertificationRepository CertificationsRepository;
        SOAPEducationTypeRepository EducationTypesRepositories;
        SOAPEducationProgramRepository SOAPEducationProgramRepositories;
        SOAPUsersRepository SOAPUsersRepositories;


        public SOAPCategoryRepository Categories => CategoriesRepository ?? (CategoriesRepository = new SOAPCategoryRepository(soap));
        public SOAPCertificationRepository Certifications => CertificationsRepository ?? (CertificationsRepository = new SOAPCertificationRepository(soap));
        public SOAPEducationTypeRepository EducationTypes => EducationTypesRepositories ?? (EducationTypesRepositories = new SOAPEducationTypeRepository(soap));
        public SOAPEducationProgramRepository EducationPrograms => SOAPEducationProgramRepositories ?? (SOAPEducationProgramRepositories = new SOAPEducationProgramRepository(soap));
        public SOAPUsersRepository Users => SOAPUsersRepositories ?? (SOAPUsersRepositories = new SOAPUsersRepository(soap));


        public ICommonRepository<T> Repository<T>()
        {
            var properties = typeof(DataManager1C).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            ICommonRepository<T> result = null;

            foreach ( var property in properties)
            {
                if (property.PropertyType == typeof(ICommonRepository<T>)) {
                    result = property.GetValue(this) as ICommonRepository<T>;
                }
            }

            return result;
        }
    }
}
