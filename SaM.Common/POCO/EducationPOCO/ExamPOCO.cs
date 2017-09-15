using System;
using System.Collections.Generic;

namespace SaM.Common.POCO
{
    public class ExamPOCO
    {
        public Int32 Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Int32 Grade { get; set; }

        public UserPOCO User { get; set; }

        public StatementPOCO Statement { get; set; }

        public ICollection<ExamCommentPOCO> Comments { get; set; }
    }
}
