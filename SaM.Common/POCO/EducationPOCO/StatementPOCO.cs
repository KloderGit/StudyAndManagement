using System;
using System.Collections.Generic;

namespace SaM.Common.POCO
{
    public class StatementPOCO
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public ICollection<SharedStatementPOCO> Programs { get; set; }

        public SubjectPOCO Subject { get; set; }

        public UserPOCO User { get; set; }

        public CertificationPOCO Certification { get; set; }

        public GroupPOCO Group { get; set; }

        public ICollection<ExamPOCO> Exams { get; set; }
    }
}
