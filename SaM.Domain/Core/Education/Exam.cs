using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SaM.Domain.Core.Education
{
    public class Exam : IDBObject
    {
        public Exam()
        {
            Comments = new HashSet<ExamComment>();
            updated = DateTime.Today;
        }

        public Int32 Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public Int32? Grade { get; set; }

        public Int32? StudentId { get; set; }
        public virtual Core.User.User Student { get; set; }

        public Int32 EventId { get; set; }
        public virtual Event Event { get; set; }

        public virtual ICollection<ExamComment> Comments { get; set; }

        private DateTime updated;
        public DateTime? Updated { get => updated; }
    }
}
