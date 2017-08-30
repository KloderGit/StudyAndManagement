using Microsoft.EntityFrameworkCore;
using SaM.Domain.Core.Education;
using SaM.Domain.Core.User;

namespace SaM.DataBases.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        #region Описание Учебного плана и групп обучения
            public DbSet<Category> Categories { get; set; }
            public DbSet<EducationalPlan> EducationalPlans { get; set; }
            public DbSet<EducationType> EducationTypes { get; set; }
            public DbSet<Group> Groups { get; set; }
            public DbSet<EducationProgram> EducationPrograms { get; set; }
            public DbSet<SubGroup> SubGroups { get; set; }
            public DbSet<Subject> Subjects { get; set; }
            public DbSet<Certification> Certifications { get; set; }
            public DbSet<CertificationType> CertificationTypes { get; set; }
            public DbSet<Exam> Exams { get; set; }
            public DbSet<ExamComment> ExamComments { get; set; }
            public DbSet<Statement> Statements { get; set; }
            public DbSet<SharedStatement> SharedStatements { get; set; }
        #endregion

        #region Данные о пользователе
            public DbSet<User> Users { get; set; }
            public DbSet<UserProfile> UserProfiles { get; set; }
            public DbSet<UserPhoto> UserPhotos { get; set; }
            public DbSet<UserLocation> UserLocations { get; set; }
            public DbSet<UserCard> UserCards { get; set; }
            public DbSet<UserContract> UserContracts { get; set; }
            public DbSet<UserComment> UserComments { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StudyAndManagementLocal;Trusted_Connection=True;");
        }

    }
}
