using Mapster;
using SaM.Common.POCO;
using SaM.DataBases.EntityFramework;
using SaM.DataBases.Infrastructure;
using SaM.DataBases.Migrations;
using SaM.Domain.Core.Education;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaM.BusinessLogic.AdminFacade.Builders
{
    public class EducationPlanDirector
    {
        IEducationBuilder builder;

        public EducationPlanDirector(IEducationBuilder builder)
        {
            this.builder = builder;
        }

        public void Build()
        {
            builder.GetNewItems();
            builder.Updated();
        }
    }


    public class EducationPlanBuilder : IEducationBuilder
    {

        IEnumerable<EducationalPlanPOCO> serviceItems;
        List<EducationalPlan> result = new List<EducationalPlan>();

        List<EducationalPlanPOCO> expextItems = new List<EducationalPlanPOCO>();

        IEnumerable<EducationProgram> programsChidren = new List<EducationProgram>();
        IEnumerable<Subject> subjectsChidren = new List<Subject>();
        IEnumerable<Certification> certificationChidren = new List<Certification>();

        public IUnitOfWorkEF database;

        public EducationPlanBuilder(IEnumerable<EducationalPlanPOCO> serviceItems)
        {
            database = new DataManagerEF();
            this.serviceItems = serviceItems;
        }


        public void GetExistingItems()
        {
            throw new NotImplementedException();
        }

        public void GetNewItems()
        {
            var dbPlan = database.EducationalPlans.GetList()
                                .IncludeMultiple(m => m.Certification)
                                .IncludeMultiple(m => m.EducationProgram)
                                .IncludeMultiple(m => m.Subject).ToList();

            foreach (var item in serviceItems)
            {
                var dbItem = dbPlan.Where(d => d.EducationProgram.Guid == item.EducationProgram.Guid)
                                   .Where(s => s.Subject.Guid == item.Subject.Guid)
                                   .Where(t => t.Certification?.Guid == item.Certification?.Guid);

                if (dbItem.Count() == 0) { expextItems.Add(item); }

            }
        }

        public void UpdatePrograms()
        {
            var progrms = serviceItems.Select(pr => pr.EducationProgram)
                                .Where(f => String.IsNullOrEmpty(f.Guid.ToString()) == false)
                                .GroupBy(x => x.Guid)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .Select(zx => zx.Value);

            var builder = new EducationProgramBuilder(progrms);
            var director = new EducationProgramDirector(builder);

            director.Build();

            programsChidren = builder.GetResult();
        }

        public void UpdateSubjects()
        {
            var subjects = serviceItems.Select(p => p.Subject)
                            .Where(f => String.IsNullOrEmpty(f.Guid.ToString()) == false)
                                .GroupBy(x => x.Guid)
                                .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                                .Select(zx => zx.Value);

            var builder = new SubjectBuilder(subjects);
            var director = new SubjectDirector(builder);

            director.Build();

            subjectsChidren = builder.GetResult();
        }

        public void GetCertifications()
        {
            var certificatuionsGUIDs = serviceItems.Select(p => p.Certification?.Guid);

            certificationChidren = database.Certifications.GetList().Where(it => certificatuionsGUIDs.Contains( it.Guid )).ToList();
        }


        public void DeleteDiferent() {

            var childProgramGUIDs = programsChidren.Select(p => p.Guid);

            var programsDataBase = database.EducationPrograms.GetList()
                                .Where(p => childProgramGUIDs.Contains( p.Guid ) )
                                .IncludeMultiple(ep => ep.EducationalPlanList);

            var eduList = programsDataBase.SelectMany(l => l.EducationalPlanList);
                                        //.IncludeMultiple(p => p.EducationProgram)
                                        //.IncludeMultiple(s => s.Subject)
                                        //.IncludeMultiple(c => c.Certification)
                                        //.ToList();

            ICollection<int> Ids = new List<int>();

            foreach (var item in programsChidren)
            {
                var planDB = eduList.Where(e => e.EducationProgram.Guid == item.Guid);
                var planServ = serviceItems.Where(e => e.EducationProgram.Guid == item.Guid);

                foreach (var planItem in planDB)
                {

                    var res = planServ.Where(p => p.EducationProgram.Guid == planItem.EducationProgram.Guid)
                                      .Where(s => s.Subject.Guid == planItem.Subject.Guid)
                                      .Where(c => c.Certification?.Guid == planItem.Certification?.Guid)
                                      .FirstOrDefault();

                    if (res == null) { Ids.Add( planItem.Id ); }
                }

            }



        }


        public void Updated()
        {
            UpdatePrograms();

            UpdateSubjects();

            GetCertifications();

            foreach (var item in expextItems)
            {
                var program = programsChidren.FirstOrDefault(k => k.Guid == item.EducationProgram.Guid);
                var subj = subjectsChidren.FirstOrDefault(t => t.Guid == item.Subject.Guid);

                var itemCert = item.Certification?.Guid;

                var cert = itemCert == null ? null : database.Certifications.GetList().Where(c => c.Guid == itemCert).FirstOrDefault();

                if (program != null && subj != null)
                {
                    database.EducationalPlans.Add(new EducationalPlan {
                        EducationProgramId = program.Id,
                        SubjectId = subj.Id,
                        CertificationId = cert?.Id,
                        Duration = item.Duration,
                        Updated = DateTime.Today
                    });
                }
            }

            database.Save();


            DeleteDiferent();
        }
    }
}
