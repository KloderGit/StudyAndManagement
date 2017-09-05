using System;
using System.Collections.Generic;
using System.Text;
using SaM.Domain.Interfaces.Repositories;
using SoapService1C;

namespace SaM.Services.Repository1C
{
    public class DataManager1C : IDataManager1C
    {

        ПФ_ПорталДПОPortTypeClient soap;

        public DataManager1C()
        {
            soap = new ПФ_ПорталДПОPortTypeClient(ПФ_ПорталДПОPortTypeClient.EndpointConfiguration.ПФ_ПорталДПОSoap);
        }

        SOAPCategoryRepository CategoriesRepository;
        SOAPCertificationRepository CertificationsRepository;
        SOAPEducationTypeRepository EducationTypesRepositories;


        public ICategoryRepository<ГруппаПрограммыОбучения> Categories => CategoriesRepository ?? (CategoriesRepository = new SOAPCategoryRepository(soap));

        public ICertificationRepository<ФормаКонтроля> Certifications => CertificationsRepository ?? (CertificationsRepository = new SOAPCertificationRepository(soap));

        public IEducationTypeRepository<ФормаОбучения> EducationTypes => EducationTypesRepositories ?? (EducationTypesRepositories = new SOAPEducationTypeRepository(soap));


        int t = 99;
    }
}
