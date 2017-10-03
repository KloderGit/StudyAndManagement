using SaM.Domain.Core.Education;
using SaM.Domain.Core.User;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.DataBases.EntityFramework
{
    public interface IUnitOfWorkEF
    {
        IRepository<Category> Categories { get; }
        IRepository<EducationalPlan> EducationalPlans { get; }
        IRepository<EducationType> EducationTypes { get; }
        IRepository<Group> Groups { get; }
        IRepository<EducationProgram> EducationPrograms { get; }
        IRepository<Exam> Exams { get; }
        IRepository<ExamComment> ExamComments { get; }
        IRepository<Statement> Statements { get; }
        IRepository<Event> SharedStatements { get; }
        IRepository<SubGroup> SubGroups { get; }
        IRepository<Subject> Subjects { get; }
        IRepository<Certification> Certifications { get; }
        IRepository<CertificationType> CertificationTypes { get; }
        IRepository<Attestation> Attestations { get; }

        IRepository<User> Users { get; }
        IRepository<UserCard> UserCards { get; }
        IRepository<UserComment> UserComments { get; }
        IRepository<UserContract> UserContracts { get; }
        IRepository<UserLocation> UserLocations { get; }
        IRepository<UserPhoto> UserPhotos { get; }
        IRepository<UserProfile> UserProfiles { get; }

        IRepository<T> Repository<T>();

        void Save();
    }
}
