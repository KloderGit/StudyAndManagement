using System;

namespace SaM.Common.POCO
{
    public class EducationalPlanPOCO
    {
        public Int32 Id { get; set; }
        
        public EducationProgramPOCO EducationProgram { get; set; }

        public SubjectPOCO Subject { get; set; }

        public CertificationPOCO Certification { get; set; }

        public Int32? Duration { get; set; }

    }
}
