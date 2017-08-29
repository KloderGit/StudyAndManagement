using SaM.Domain.Core.Education;
using SaM.Domain.Core.User;
using System;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface IDataManager : IDisposable
    {
        ICategoryRepository<Category> Categories { get; }
        IEducationalPlanRepository<EducationalPlan> EducationalPlans { get; }
        IEducationTypeRepository<EducationType> EducationTypes { get; }
        IGroupRepository<Group> Groups { get; }
        IEducationProgramRepository<EducationProgram> EducationPrograms { get; }
        IExamRepository<Exam> Exams { get; }
        IExamCommentRepository<ExamComment> ExamComments { get; }
        IStatementRepository<Statement> Statements { get; }
        ISharedStatementRepository<SharedStatement> SharedStatements { get; }
        ISubGroupRepository<SubGroup> SubGroups { get; }
        ISubjectRepository<Subject> Subjects { get; }
        ICertificationRepository<Certification> Certifications { get; }
        ICertificationTypeRepository<CertificationType> CertificationTypes { get; }

        IUserRepository<User> Users { get; }
        IUserCardRepository<UserCard> UserCards { get; }
        IUserCommentRepository<UserComment> UserComments { get; }
        IUserContractRepository<UserContract> UserContracts { get; }
        IUserLocationRepository<UserLocation> UserLocations { get; }
        IUserPhotoRepository<UserPhoto> UserPhotos { get; }
        IUserProfileRepository<UserProfile> UserProfiles { get; }

        void Save();
    }
}
