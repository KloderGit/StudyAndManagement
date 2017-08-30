using System;
using System.Collections.Generic;

namespace SaM.BusinessLogic.POCO
{
    public class EducationProgramPOCO
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public DateTime AcceptDate { get; set; }
        public string ProgramType { get; set; }
        public string StudyType { get; set; }

        public CategoryPOCO Category { get; set; }

        public EducationTypePOCO EducationType { get; set; }

        public ICollection<EducationalPlanPOCO> EducationalPlanList { get; set; }
    }
}
