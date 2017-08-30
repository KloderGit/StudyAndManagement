using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;

namespace SaM.BusinessLogic.DAL.RepositoryPOCO
{
    public interface IDataManagerPOCO
    {
        ICategoryRepository<CategoryPOCO> Categories { get; }
        IEducationalPlanRepository<EducationalPlanPOCO> EducationalPlans { get; }
        IEducationTypeRepository<EducationTypePOCO> EducationTypes { get; }
        IGroupRepository<GroupPOCO> Groups { get; }
        IEducationProgramRepository<EducationProgramPOCO> EducationPrograms { get; }
        IExamRepository<ExamPOCO> Exams { get; }
        IExamCommentRepository<ExamCommentPOCO> ExamComments { get; }
        IStatementRepository<StatementPOCO> Statements { get; }
        ISharedStatementRepository<SharedStatementPOCO> SharedStatements { get; }
        ISubGroupRepository<SubGroupPOCO> SubGroups { get; }
        ISubjectRepository<SubjectPOCO> Subjects { get; }
        ICertificationRepository<CertificationPOCO> Certifications { get; }
        ICertificationTypeRepository<CertificationTypePOCO> CertificationTypes { get; }

        IUserRepository<UserPOCO> Users { get; }
        IUserCardRepository<UserCardPOCO> UserCards { get; }
        IUserCommentRepository<UserCommentPOCO> UserComments { get; }
        IUserContractRepository<UserContractPOCO> UserContracts { get; }
        IUserLocationRepository<UserLocationPOCO> UserLocations { get; }
        IUserPhotoRepository<UserPhotoPOCO> UserPhotos { get; }
        IUserProfileRepository<UserProfilePOCO> UserProfiles { get; }

        void Save();
    }
}
