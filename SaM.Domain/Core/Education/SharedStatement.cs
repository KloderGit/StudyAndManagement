using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class SharedStatement
    {
        public Int32 Id { get; set; }

        public Int32 EducationProgramId { get; set; }
        public virtual EducationProgram EducationProgram { get; set; }

        public Int32 StatementId { get; set; }
        public virtual Statement Statement { get; set; }
    }
}
