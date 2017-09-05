using SaM.Domain.Interfaces.Repositories;
using SoapService1C;

namespace SaM.Services.Repository1C
{
    public interface IDataManager1C
    {
        ICategoryRepository<ГруппаПрограммыОбучения> Categories { get; }
        ICertificationRepository<ФормаКонтроля> Certifications { get; }
        IEducationTypeRepository<ФормаОбучения> EducationTypes { get; }
    }
}
