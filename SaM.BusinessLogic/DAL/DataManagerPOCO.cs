using SaM.BusinessLogic.DAL.RepositoryPOCO;
using SaM.BusinessLogic.POCO;
using SaM.Domain.Interfaces.Repositories;
using System;

namespace SaM.BusinessLogic.DAL
{
    public class DataManagerPOCO : IDataManagerPOCO
    {
        IDataManager datamanager;

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

        public DataManagerPOCO(IDataManager datamanager)
        {
            this.datamanager = datamanager;
        }

        public ICategoryRepository<CategoryPOCO> Categories => Category ?? (Category = new POCOCategoryRepository(datamanager.Categories) );

        public IEducationalPlanRepository<EducationalPlanPOCO> EducationalPlans => EducationPlan ?? (EducationPlan = new POCOEducationalPlanRepository(datamanager.EducationalPlans) );

        public IEducationTypeRepository<EducationTypePOCO> EducationTypes => EducationType ?? (EducationType = new POCOEducationTypeRepository(datamanager.EducationTypes) );

        public IGroupRepository<GroupPOCO> Groups => Group ?? (Group = new POCOGroupRepository(datamanager.Groups) );

        public IEducationProgramRepository<EducationProgramPOCO> EducationPrograms => EducationProgram ?? (EducationProgram = new POCOEducationProgramRepository(datamanager.EducationPrograms) );

        public IExamRepository<ExamPOCO> Exams => Exam ?? (Exam = new POCOExamRepository(datamanager.Exams) );

        public IExamCommentRepository<ExamCommentPOCO> ExamComments => ExamComment ?? (ExamComment = new POCOExamCommentsRepository(datamanager.ExamComments) );

        public IStatementRepository<StatementPOCO> Statements => Statement ?? (Statement = new POCOStatementRepository(datamanager.Statements) );

        public ISharedStatementRepository<SharedStatementPOCO> SharedStatements => SharedStatement ?? (SharedStatement = new POCOSharedStatementRepository(datamanager.SharedStatements) );

        public ISubGroupRepository<SubGroupPOCO> SubGroups => SubGroup ?? (SubGroup = new POCOSubGroupRepository(datamanager.SubGroups) );

        public ISubjectRepository<SubjectPOCO> Subjects => Subject ?? (Subject = new POCOSubjectRepository(datamanager.Subjects) );

        public ICertificationRepository<CertificationPOCO> Certifications => Certification ?? (Certification = new POCOCertificationRepository(datamanager.Certifications) );

        public ICertificationTypeRepository<CertificationTypePOCO> CertificationTypes => CertificationType ?? (CertificationType = new POCOCertificationTypeRepository(datamanager.CertificationTypes) );


        public IUserRepository<UserPOCO> Users => User ?? (User = new POCOUserRepository(datamanager.Users) );

        public IUserCardRepository<UserCardPOCO> UserCards => UserCard ?? (UserCard = new POCOUserCardRepository(datamanager.UserCards) );

        public IUserCommentRepository<UserCommentPOCO> UserComments => UserComment ?? (UserComment = new POCOUserCommentsRepository(datamanager.UserComments) );

        public IUserContractRepository<UserContractPOCO> UserContracts => UserContract ?? (UserContract = new POCOUserContractRepository(datamanager.UserContracts) );

        public IUserLocationRepository<UserLocationPOCO> UserLocations => UserLocation ?? (UserLocation = new POCOUserLocationRepository(datamanager.UserLocations) );

        public IUserPhotoRepository<UserPhotoPOCO> UserPhotos => UserPhoto ?? (UserPhoto = new POCOUserPhotoRepository(datamanager.UserPhotos) );

        public IUserProfileRepository<UserProfilePOCO> UserProfiles => UserProfile ?? (UserProfile = new POCOUserProfileRepository(datamanager.UserProfiles) );


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
