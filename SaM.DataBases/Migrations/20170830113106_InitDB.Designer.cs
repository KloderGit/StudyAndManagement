﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SaM.DataBases.EntityFramework;

namespace SaM.DataBases.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20170830113106_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SaM.Domain.Core.Education.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Guid");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.Certification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Guid");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Certifications");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.CertificationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AssessmentId");

                    b.Property<Guid>("Guid");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentId");

                    b.ToTable("CertificationTypes");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.EducationalPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EducationProgramId");

                    b.Property<int>("SubjectId");

                    b.HasKey("Id");

                    b.HasIndex("EducationProgramId");

                    b.HasIndex("SubjectId");

                    b.ToTable("EducationalPlans");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.EducationProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AcceptDate");

                    b.Property<bool>("Active");

                    b.Property<int?>("CategoryId");

                    b.Property<int?>("EducationTypeId");

                    b.Property<Guid>("Guid");

                    b.Property<string>("ProgramType");

                    b.Property<string>("StudyType");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EducationTypeId");

                    b.ToTable("EducationPrograms");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.EducationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Guid");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("EducationTypes");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("End");

                    b.Property<int>("Grade");

                    b.Property<DateTime>("Start");

                    b.Property<int>("StatementId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("StatementId");

                    b.HasIndex("UserId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.ExamComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExamId");

                    b.Property<string>("Text");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("UserId");

                    b.ToTable("ExamComments");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Guid");

                    b.Property<int>("ProgramId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.SharedStatement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EducationProgramId");

                    b.Property<int>("StatementId");

                    b.HasKey("Id");

                    b.HasIndex("EducationProgramId");

                    b.HasIndex("StatementId");

                    b.ToTable("SharedStatements");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.Statement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CertificationId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("GroupId");

                    b.Property<Guid>("Guid");

                    b.Property<int>("SubjectId");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CertificationId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Statements");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.SubGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GroupId");

                    b.Property<Guid>("Guid");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("SubGroups");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CertificationId");

                    b.Property<int?>("Duration");

                    b.Property<Guid>("Guid");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CertificationId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SaM.Domain.Core.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<Guid>("Guid");

                    b.Property<string>("LastName");

                    b.Property<string>("ParentMidleName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Guid");

                    b.Property<string>("Number");

                    b.Property<string>("PassCode");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserCards");
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserComments");
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CloseDate");

                    b.Property<DateTime?>("EducationEnd");

                    b.Property<int>("EducationProgramId");

                    b.Property<DateTime?>("EducationStart");

                    b.Property<int?>("GroupId");

                    b.Property<Guid>("Guid");

                    b.Property<DateTime>("OpenDate");

                    b.Property<double?>("Pay");

                    b.Property<string>("Result");

                    b.Property<int?>("SubGroupId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EducationProgramId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserContracts");
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Post");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserLocations");
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserPhoto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Url");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserPhotos");
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<bool>("Excellent");

                    b.Property<string>("Gender");

                    b.Property<string>("Phone");

                    b.Property<string>("Skype");

                    b.Property<int>("UserId");

                    b.Property<string>("WWW");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.CertificationType", b =>
                {
                    b.HasOne("SaM.Domain.Core.Education.Certification", "Assessment")
                        .WithMany("CertificationTypeList")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.EducationalPlan", b =>
                {
                    b.HasOne("SaM.Domain.Core.Education.EducationProgram", "EducationProgram")
                        .WithMany("EducationalPlanList")
                        .HasForeignKey("EducationProgramId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaM.Domain.Core.Education.Subject", "Subject")
                        .WithMany("EducationalPlanList")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.EducationProgram", b =>
                {
                    b.HasOne("SaM.Domain.Core.Education.Category", "Category")
                        .WithMany("Programs")
                        .HasForeignKey("CategoryId");

                    b.HasOne("SaM.Domain.Core.Education.EducationType", "EducationType")
                        .WithMany()
                        .HasForeignKey("EducationTypeId");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.Exam", b =>
                {
                    b.HasOne("SaM.Domain.Core.Education.Statement", "Statement")
                        .WithMany("Exams")
                        .HasForeignKey("StatementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaM.Domain.Core.User.User", "User")
                        .WithMany("Exams")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.ExamComment", b =>
                {
                    b.HasOne("SaM.Domain.Core.Education.Exam", "Exam")
                        .WithMany("Comments")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaM.Domain.Core.User.User", "User")
                        .WithMany("ExamComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.Group", b =>
                {
                    b.HasOne("SaM.Domain.Core.Education.EducationProgram", "Program")
                        .WithMany()
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.SharedStatement", b =>
                {
                    b.HasOne("SaM.Domain.Core.Education.EducationProgram", "EducationProgram")
                        .WithMany()
                        .HasForeignKey("EducationProgramId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaM.Domain.Core.Education.Statement", "Statement")
                        .WithMany("Programs")
                        .HasForeignKey("StatementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.Statement", b =>
                {
                    b.HasOne("SaM.Domain.Core.Education.Certification", "Certification")
                        .WithMany()
                        .HasForeignKey("CertificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaM.Domain.Core.Education.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("SaM.Domain.Core.Education.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaM.Domain.Core.User.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.SubGroup", b =>
                {
                    b.HasOne("SaM.Domain.Core.Education.Group", "Group")
                        .WithMany("SubGroupList")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.Education.Subject", b =>
                {
                    b.HasOne("SaM.Domain.Core.Education.Certification", "Certification")
                        .WithMany()
                        .HasForeignKey("CertificationId");
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserCard", b =>
                {
                    b.HasOne("SaM.Domain.Core.User.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserComment", b =>
                {
                    b.HasOne("SaM.Domain.Core.User.User", "User")
                        .WithMany("UserComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserContract", b =>
                {
                    b.HasOne("SaM.Domain.Core.Education.EducationProgram", "EducationProgram")
                        .WithMany()
                        .HasForeignKey("EducationProgramId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaM.Domain.Core.Education.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("SaM.Domain.Core.Education.SubGroup", "SubGroup")
                        .WithMany()
                        .HasForeignKey("SubGroupId");

                    b.HasOne("SaM.Domain.Core.User.User", "User")
                        .WithMany("Contracts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserLocation", b =>
                {
                    b.HasOne("SaM.Domain.Core.User.User", "User")
                        .WithOne("Location")
                        .HasForeignKey("SaM.Domain.Core.User.UserLocation", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserPhoto", b =>
                {
                    b.HasOne("SaM.Domain.Core.User.User", "User")
                        .WithOne("Photo")
                        .HasForeignKey("SaM.Domain.Core.User.UserPhoto", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaM.Domain.Core.User.UserProfile", b =>
                {
                    b.HasOne("SaM.Domain.Core.User.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("SaM.Domain.Core.User.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
