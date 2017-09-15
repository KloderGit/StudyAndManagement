using SaM.Domain.Interfaces.Repositories;
using SaM.Domain.Core.Education;
using SaM.Domain.Core.User;

namespace SaM.DataBases.EntityFramework
{
    public class DataManagerEF : IUnitOfWorkEF
    {
        private ApplicationContext db;

        CommonImplementEFRepository<Category> Category;
        CommonImplementEFRepository<EducationalPlan> EducationPlan;
        CommonImplementEFRepository<EducationType> EducationType;
        CommonImplementEFRepository<Group> Group;
        CommonImplementEFRepository<EducationProgram> EducationProgram;
        CommonImplementEFRepository<Exam> Exam;
        CommonImplementEFRepository<ExamComment> ExamComment;
        CommonImplementEFRepository<Statement> Statement;
        CommonImplementEFRepository<SharedStatement> SharedStatement;
        CommonImplementEFRepository<SubGroup> SubGroup;
        CommonImplementEFRepository<Subject> Subject;
        CommonImplementEFRepository<Certification> Certification;
        CommonImplementEFRepository<CertificationType> CertificationType;

        CommonImplementEFRepository<User> User;
        CommonImplementEFRepository<UserCard> UserCard;
        CommonImplementEFRepository<UserComment> UserComment;
        CommonImplementEFRepository<UserContract> UserContract;
        CommonImplementEFRepository<UserLocation> UserLocation;
        CommonImplementEFRepository<UserPhoto> UserPhoto;
        CommonImplementEFRepository<UserProfile> UserProfile;

        public DataManagerEF()
        {
            db = new ApplicationContext();
        }

        public IRepository<Category> Categories => Category ?? (Category = new CommonImplementEFRepository<Category>(db));
        public IRepository<EducationalPlan> EducationalPlans => EducationPlan ?? (EducationPlan = new CommonImplementEFRepository<EducationalPlan>(db));
        public IRepository<EducationType> EducationTypes => EducationType ?? (EducationType = new CommonImplementEFRepository<EducationType>(db));
        public IRepository<Group> Groups => Group ?? (Group = new CommonImplementEFRepository<Group>(db));
        public IRepository<EducationProgram> EducationPrograms => EducationProgram ?? (EducationProgram = new CommonImplementEFRepository<EducationProgram>(db));
        public IRepository<Exam> Exams => Exam ?? (Exam = new CommonImplementEFRepository<Exam>(db));
        public IRepository<ExamComment> ExamComments => ExamComment ?? (ExamComment = new CommonImplementEFRepository<ExamComment>(db));
        public IRepository<Statement> Statements => Statement ?? (Statement = new CommonImplementEFRepository<Statement>(db));
        public IRepository<SharedStatement> SharedStatements => SharedStatement ?? (SharedStatement = new CommonImplementEFRepository<SharedStatement>(db));
        public IRepository<SubGroup> SubGroups => SubGroup ?? (SubGroup = new CommonImplementEFRepository<SubGroup>(db));
        public IRepository<Subject> Subjects => Subject ?? (Subject = new CommonImplementEFRepository<Subject>(db));
        public IRepository<Certification> Certifications => Certification ?? (Certification = new CommonImplementEFRepository<Certification>(db));
        public IRepository<CertificationType> CertificationTypes => CertificationType ?? (CertificationType = new CommonImplementEFRepository<CertificationType>(db));

        public IRepository<User> Users => User ?? (User = new CommonImplementEFRepository<User>(db));
        public IRepository<UserCard> UserCards => UserCard ?? (UserCard = new CommonImplementEFRepository<UserCard>(db));
        public IRepository<UserComment> UserComments => UserComment ?? (UserComment = new CommonImplementEFRepository<UserComment>(db));
        public IRepository<UserContract> UserContracts => UserContract ?? (UserContract = new CommonImplementEFRepository<UserContract>(db));
        public IRepository<UserLocation> UserLocations => UserLocation ?? (UserLocation = new CommonImplementEFRepository<UserLocation>(db));
        public IRepository<UserPhoto> UserPhotos => UserPhoto ?? (UserPhoto = new CommonImplementEFRepository<UserPhoto>(db));
        public IRepository<UserProfile> UserProfiles => UserProfile ?? (UserProfile = new CommonImplementEFRepository<UserProfile>(db));

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
