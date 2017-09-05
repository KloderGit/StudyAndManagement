using System;

namespace SaM.Common.POCO
{
    public class SharedStatementPOCO
    {
        public Int32 Id { get; set; }

        public EducationProgramPOCO EducationProgram { get; set; }

        public StatementPOCO Statement { get; set; }
    }
}
