using System;
using System.Collections.Generic;

namespace SaM.Domain.Core.Education
{
    public class Statement
    {
        public Statement()
        {
            Exams = new HashSet<Exam>();
        }

        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public Int32 EducationalPlanId { get; set; }
        public virtual EducationalPlan EducationalPlan { get; set; }

        public Int32 UserId { get; set; }
        public virtual Core.User.User User { get; set; }

        public Int32? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }

        public DateTime? Updated { get; set; }
    }
}
