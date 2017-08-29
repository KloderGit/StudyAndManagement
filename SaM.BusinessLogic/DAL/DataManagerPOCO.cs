using SaM.BusinessLogic.DAL.RepositoryPOCO;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using System;

namespace SaM.BusinessLogic.DAL
{
    public class DataManagerPOCO : IDataManagerPOCO
    {
        POCOCategoryRepository Category;
        POCOEducationalPlanRepository EducationPlan;
        POCOEducationTypeRepository EducationType;
        POCOGroupRepository Group;
        POCOEducationProgramRepository EducationProgram;
        POCOExamRepository Exam;
        POCOExamCommentsRepository ExamComment;
        POCOStatementRepository Statement;
        POCOSharedStatementRepository SharedStatement;
        POCOSubGroupRepository SubGroup;
        POCOSubjectRepository Subject;
        POCOCertificationRepository Certification;
        POCOCertificationTypeRepository CertificationType;

        POCOUserRepository User;
        POCOUserCardRepository UserCard;
        POCOUserCommentsRepository UserComment;
        POCOUserContractRepository UserContract;
        POCOUserLocationRepository UserLocation;
        POCOUserPhotoRepository UserPhoto;
        POCOUserProfileRepository UserProfile;

        public DataManagerPOCO()
        {
        }

        public ICategoryRepository<CategoryPOCO> Categories => Category ?? (Category = new POCOCategoryRepository());

        public IEducationalPlanRepository<EducationalPlanPOCO> EducationalPlans => EducationPlan ?? (EducationPlan = new POCOEducationalPlanRepository());

        public IEducationTypeRepository<EducationTypePOCO> EducationTypes => EducationType ?? (EducationType = new POCOEducationTypeRepository());

        public IGroupRepository<GroupPOCO> Groups => Group ?? (Group = new POCOGroupRepository());

        public IEducationProgramRepository<EducationProgramPOCO> EducationPrograms => EducationProgram ?? (EducationProgram = new POCOEducationProgramRepository());

        public IExamRepository<ExamPOCO> Exams => Exam ?? (Exam = new POCOExamRepository());

        public IExamCommentRepository<ExamCommentPOCO> ExamComments => ExamComment ?? (ExamComment = new POCOExamCommentsRepository());

        public IStatementRepository<StatementPOCO> Statements => Statement ?? (Statement = new POCOStatementRepository());

        public ISharedStatementRepository<SharedStatementPOCO> SharedStatements => SharedStatement ?? (SharedStatement = new POCOSharedStatementRepository());

        public ISubGroupRepository<SubGroupPOCO> SubGroups => SubGroup ?? (SubGroup = new POCOSubGroupRepository());

        public ISubjectRepository<SubjectPOCO> Subjects => Subject ?? (Subject = new POCOSubjectRepository());

        public ICertificationRepository<CertificationPOCO> Certifications => Certification ?? (Certification = new POCOCertificationRepository());

        public ICertificationTypeRepository<CertificationTypePOCO> CertificationTypes => CertificationType ?? (CertificationType = new POCOCertificationTypeRepository());


        public IUserRepository<UserPOCO> Users => User ?? (User = new POCOUserRepository());

        public IUserCardRepository<UserCardPOCO> UserCards => UserCard ?? (UserCard = new POCOUserCardRepository());

        public IUserCommentRepository<UserCommentPOCO> UserComments => UserComment ?? (UserComment = new POCOUserCommentsRepository());

        public IUserContractRepository<UserContractPOCO> UserContracts => UserContract ?? (UserContract = new POCOUserContractRepository());

        public IUserLocationRepository<UserLocationPOCO> UserLocations => UserLocation ?? (UserLocation = new POCOUserLocationRepository());

        public IUserPhotoRepository<UserPhotoPOCO> UserPhotos => UserPhoto ?? (UserPhoto = new POCOUserPhotoRepository());

        public IUserProfileRepository<UserProfilePOCO> UserProfiles => UserProfile ?? (UserProfile = new POCOUserProfileRepository());


        public void Save()
        {
        }


        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
