using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.DTO
{
    public class EducationalPlanDTO
    {
        public EducationProgramDTO EducationProgram { get; set; }

        public SubjectDTO Subject { get; set; }

        public Int32? Duration { get; set; }

        public CertificationDTO Certification { get; set; }

    }
}
