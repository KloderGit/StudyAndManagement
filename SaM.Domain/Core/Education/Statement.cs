using System;
using System.Collections.Generic;

namespace SaM.Domain.Core.Education
{
    public class Statement
    {
        public Statement()
        {
            Exams = new HashSet<Exam>();
            Programs = new HashSet<SharedStatement>();
        }

        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<SharedStatement> Programs { get; set; }

        public Int32 SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public Int32 UserId { get; set; }
        public virtual Core.User.User User { get; set; }

        public Int32 CertificationId { get; set; }
        public virtual Certification Certification { get; set; }

        public Int32? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
