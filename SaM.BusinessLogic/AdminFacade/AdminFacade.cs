using Mapster;
using Microsoft.EntityFrameworkCore;
using SaM.BusinessLogic.AdminFacade.Builders;
using SaM.BusinessLogic.AdminFacade.UpdateEntity;
using SaM.Common.DTO;
using SaM.Common.Infrastructure;
using SaM.Common.Infrastructure.Mapster;
using SaM.Common.POCO;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using SoapService1full;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SaM.BusinessLogic.AdminFacade
{
    public class AdminFacade
    {
        public IEnumerable<EducationProgramPOCO> GetPrograms() {

            var db = new ApplicationContext();

            var result = db.EducationPrograms
                .Include(cat => cat.Category)
                .Include(pt => pt.EducationType)
                .Include(pl => pl.EducationalPlanList)
                    .ThenInclude(p => p.Subject)
                .Include(pl => pl.EducationalPlanList)
                    .ThenInclude(p => p.Certification)
                .Adapt<IEnumerable<EducationProgram>, IEnumerable<EducationProgramPOCO>>();

            return result;
        }

        public EducationProgramPOCO GetProgram(Guid guid) {

            var db = new ApplicationContext();

            var result = db.EducationPrograms
                .Include(cat => cat.Category)
                .Include(pt => pt.EducationType)
                .Include(pl => pl.EducationalPlanList)
                    .ThenInclude(p => p.Subject)
                .Include(pl => pl.EducationalPlanList)
                    .ThenInclude(p => p.Certification)
                .First(p => p.Guid == guid)
                .Adapt<EducationProgram, EducationProgramPOCO>();

            return result;
        }

        public void DeleteSubject(Guid guid)
        {
            var db = new ApplicationContext();

            var elem = db.Subjects.FirstOrDefault(el => el.Guid == guid);

            db.Subjects.Remove(elem);

            db.SaveChangesAsync();
        }

        public void DeleteProgram(Guid guid)
        {
            var db = new ApplicationContext();

            var elem = db.EducationPrograms.FirstOrDefault(el => el.Guid == guid);

            db.EducationPrograms.Remove(elem);

            db.SaveChangesAsync();
        }

        public void ProgramActive(Guid guid, bool isActive)
        {
            var db = new ApplicationContext();

            var elem = db.EducationPrograms.FirstOrDefault(el => el.Guid == guid);

            elem.Active = isActive;

            db.SaveChangesAsync();
        }

        public void UpdateEducation()
        {
            var dssdd = new DataManager1C();
            var database = new DataManagerEF();

            var ddddd = dssdd.EducationPrograms.GetList(new DateTime(2017, 9, 18), DateTime.Today).Where(ac => ac.active == "Активный");


            var attest = ddddd.SelectMany(p => p.listOfSubjects)
                .Select(att => att.Attestation)
                .Where(att => String.IsNullOrEmpty(att.formControl.GUIDFormControl) == false)
                    .GroupBy(x => x.formControl.GUIDFormControl)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault())
                    .SelectMany(zx => zx.Value.SpisokVariantAttestation.Select(el => new AttestationPOCO
                    {
                        Certification = zx.Value.formControl.Adapt<CertificationPOCO>(),
                        CertificationType = el.Adapt<CertificationTypePOCO>()
                    }));

            var attBuild = new AttestationBuilder(attest);
            var Attdirec = new AttestationDirector(attBuild);
            Attdirec.Build();


            var educationPlanTree = ddddd.SelectMany(r => r.listOfSubjects.Where(f => String.IsNullOrEmpty(f.GUIDsubject) == false)
                       .Select(s => new EducationalPlanPOCO
                       {
                           EducationProgram = r.Adapt<EducationProgramPOCO>(),
                           Subject = s.Adapt<SubjectPOCO>(),
                           Certification = String.IsNullOrEmpty(s.Attestation.formControl.GUIDFormControl) == false ?
                                                                s.Attestation.formControl.Adapt<CertificationPOCO>() : null,
                           Duration = s.duration.ParseIgnoreException()
                       })
                 );

            var eduPlanBuild = new EducationPlanBuilder(educationPlanTree);
            var eduDirector = new EducationPlanDirector(eduPlanBuild);
            eduDirector.Build();
        }

    }
}
