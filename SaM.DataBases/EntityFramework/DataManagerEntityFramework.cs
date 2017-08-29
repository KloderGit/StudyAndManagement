using SaM.Domain.Core.User;
using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces.Repositories;
using System;

namespace SaM.DataBases.EntityFramework
{
    public class DataManagerEntityFramework : IDataManager
    {
        private ApplicationContext db;

        EFCategoryRepository Category;
        EFEducationalPlanRepository EducationPlan;
        EFEducationTypeRepository EducationType;
        EFGroupRepository Group;
        EFEducationProgramRepository EducationProgram;
        EFExamRepository Exam;
        EFExamCommentsRepository ExamComment;
        EFStatementRepository Statement;
        EFSharedStatementRepository SharedStatement;
        EFSubGroupRepository SubGroup;
        EFSubjectRepository Subject;
        EFCertificationRepository Certification;
        EFCertificationTypeRepository CertificationType;

        EFUserRepository User;
        EFUserCardRepository UserCard;
        EFUserCommentsRepository UserComment;
        EFUserContractRepository UserContract;
        EFUserLocationRepository UserLocation;
        EFUserPhotoRepository UserPhoto;
        EFUserProfileRepository UserProfile;

        public DataManagerEntityFramework()
        {
            db = new ApplicationContext();
        }

        public ICategoryRepository<Category> Categories => Category ?? (Category = new EFCategoryRepository(db));

        public IEducationalPlanRepository<EducationalPlan> EducationalPlans => EducationPlan ?? (EducationPlan = new EFEducationalPlanRepository(db));

        public IEducationTypeRepository<EducationType> EducationTypes => EducationType ?? (EducationType = new EFEducationTypeRepository(db));

        public IGroupRepository<Group> Groups => Group ?? (Group = new EFGroupRepository(db));

        public IEducationProgramRepository<EducationProgram> EducationPrograms => EducationProgram ?? (EducationProgram = new EFEducationProgramRepository(db));

        public IExamRepository<Exam> Exams => Exam ?? (Exam = new EFExamRepository(db));

        public IExamCommentRepository<ExamComment> ExamComments => ExamComment ?? (ExamComment = new EFExamCommentsRepository(db));

        public IStatementRepository<Statement> Statements => Statement ?? (Statement = new EFStatementRepository(db));

        public ISharedStatementRepository<SharedStatement> SharedStatements => SharedStatement ?? (SharedStatement = new EFSharedStatementRepository(db));

        public ISubGroupRepository<SubGroup> SubGroups => SubGroup ?? (SubGroup = new EFSubGroupRepository(db));

        public ISubjectRepository<Subject> Subjects => Subject ?? (Subject = new EFSubjectRepository(db));

        public ICertificationRepository<Certification> Certifications => Certification ?? (Certification = new EFCertificationRepository(db));

        public ICertificationTypeRepository<CertificationType> CertificationTypes => CertificationType ?? (CertificationType = new EFCertificationTypeRepository(db));


        public IUserRepository<User> Users => User ?? (User = new EFUserRepository(db));

        public IUserCardRepository<UserCard> UserCards => UserCard ?? (UserCard = new EFUserCardRepository(db));

        public IUserCommentRepository<UserComment> UserComments => UserComment ?? (UserComment = new EFUserCommentsRepository(db));

        public IUserContractRepository<UserContract> UserContracts => UserContract ?? (UserContract = new EFUserContractRepository(db));

        public IUserLocationRepository<UserLocation> UserLocations => UserLocation ?? (UserLocation = new EFUserLocationRepository(db));

        public IUserPhotoRepository<UserPhoto> UserPhotos => UserPhoto ?? (UserPhoto = new EFUserPhotoRepository(db));

        public IUserProfileRepository<UserProfile> UserProfiles => UserProfile ?? (UserProfile = new EFUserProfileRepository(db));


        public void Save()
        {
            db.SaveChanges();
        }


        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
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
