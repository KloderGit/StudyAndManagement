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

        public ICommonRepository<ГруппаПрограммыОбучения> Categories => CategoriesRepository ?? (CategoriesRepository = new SOAPCategoryRepository(soap));
        public ICommonRepository<ФормаКонтроля> Certifications => CertificationsRepository ?? (CertificationsRepository = new SOAPCertificationRepository(soap));
        public ICommonRepository<ФормаОбучения> EducationTypes => EducationTypesRepositories ?? (EducationTypesRepositories = new SOAPEducationTypeRepository(soap));


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
