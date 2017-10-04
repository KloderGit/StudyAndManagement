using System;
using System.Collections.Generic;

namespace SaM.Common.POCO
{
    public class SubjectPOCO
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public ICollection<EducationalPlanPOCO> EducationalPlanList { get; set; }
    }
}
