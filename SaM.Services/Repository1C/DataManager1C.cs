using SaM.Domain.Interfaces.Repositories;
using SoapService1full;

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
    }
}
