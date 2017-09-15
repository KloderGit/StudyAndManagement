using System;
using System.Collections.Generic;

namespace SaM.Common.POCO
{
    public class GroupPOCO
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public EducationProgramPOCO Program { get; set; }

        public ICollection<SubGroupPOCO> SubGroupList { get; set; }
        
    }
}
