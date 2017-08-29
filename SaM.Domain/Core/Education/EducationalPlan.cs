using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class EducationalPlan
    {
        public Int32 Id { get; set; }
        
        public Int32 EducationProgramId { get; set; }
        public virtual EducationProgram EducationProgram { get; set; }

        public Int32 SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
