using SaM.Domain.Interfaces.Repositories;
using SoapService1full;

namespace SaM.Services.Repository1C
{
    public interface IUnitOfWork1C
    {
        SOAPCategoryRepository Categories { get; }
        SOAPCertificationRepository Certifications { get; }
        SOAPEducationTypeRepository EducationTypes { get; }
        SOAPEducationProgramRepository EducationPrograms { get; }

        ICommonRepository<T> Repository<T>();
    }
}