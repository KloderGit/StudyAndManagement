﻿using System;
using System.Collections.Generic;

namespace SaM.BusinessLogic.POCO
{
    public class SubjectPOCO
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public Int32? Duration { get; set; }

        public CertificationPOCO Certification { get; set; }

        public ICollection<EducationalPlanPOCO> EducationalPlanList { get; set; }
    }
}
