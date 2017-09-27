using System;
using System.Collections.Generic;

namespace SaM.Domain.Core.Education
{
    public class EducationalPlan
    {
        public EducationalPlan()
        {
            EventList = new HashSet<EducationPlanEvents>();
            Statements = new HashSet<Statement>();
        }

        public Int32 Id { get; set; }
        
        public Int32 EducationProgramId { get; set; }
        public virtual EducationProgram EducationProgram { get; set; }

        public Int32 SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public Int32? Duration { get; set; }

        public Int32? CertificationId { get; set; }
        public virtual Certification Certification { get; set; }

        public Int32? TeacherId { get; set; }
        public virtual User.User Teacher { get; set; }

        public virtual ICollection<EducationPlanEvents> EventList { get; set; }

        public virtual ICollection<Statement> Statements { get; set; }

        public DateTime? Updated { get; set; }
    }
}
