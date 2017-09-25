using SaM.Domain.Interfaces.Repositories;
using SoapService1full;

namespace SaM.Services.Repository1C
{
    public interface IUnitOfWork1C
    {
        ICommonRepository<ГруппаПрограммыОбучения> Categories { get; }
        ICommonRepository<ФормаКонтроля> Certifications { get; }
        ICommonRepository<ФормаОбучения> EducationTypes { get; }
        
    }
}