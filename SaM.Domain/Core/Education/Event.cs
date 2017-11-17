using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class Event : IDBObject
    {
        public Event()
        {
            EducationPlanEvents = new HashSet<EducationPlanEvents>();
            updated = DateTime.Today;
        }

        public Int32 Id { get; set; }
        public DateTime Date { get; set; }

        public Int32? UserId { get; set; }
        public virtual User.User Teacher { get; set; }

        public Int32? StudentsCount { get; set; }

        public virtual ICollection<EducationPlanEvents> EducationPlanEvents { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }

        public virtual ICollection<Statement> Statements { get; set; }

        private DateTime updated;
        public DateTime? Updated { get => updated; }
    }
}
