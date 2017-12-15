using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SaM.Domain.Core.Education
{
    public class EducationalPlan
    {
        public EducationalPlan()
        {
            EventList = new HashSet<EducationPlanEvents>();
        }

        public Int32 Id { get; set; }
        
        public Int32 EducationProgramId { get; set; }
        public virtual EducationProgram EducationProgram { get; set; }

        public Int32 SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public Int32? Duration { get; set; }

        public Int32 SubjectOrder { get; set; }

        public Int32? CertificationId { get; set; }
        public virtual Certification Certification { get; set; }

        public Int32? TeacherId { get; set; }
        public virtual User.User Teacher { get; set; }

        public Int32 TeacherOrder { get; set; }

        public virtual ICollection<EducationPlanEvents> EventList { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }
    }
}
