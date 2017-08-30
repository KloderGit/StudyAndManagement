using System;

namespace SaM.BusinessLogic.POCO
{
    public class UserContractPOCO
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public double? Pay { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public DateTime? EducationStart { get; set; }
        public DateTime? EducationEnd { get; set; }
        public string Result { get; set; }

        public UserPOCO User { get; set; }

        public EducationProgramPOCO EducationProgram { get; set; }

        public GroupPOCO Group { get; set; }

        public SubGroupPOCO SubGroup { get; set; }
    }
}