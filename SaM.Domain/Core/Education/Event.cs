using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class Event
    {
        public Event()
        {
            EducationPlanList = new HashSet<EducationPlanEvents>();
        }

        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public Int32? StudentsCount { get; set; }

        public virtual ICollection<EducationPlanEvents> EducationPlanList { get; set; }

        public DateTime? Updated { get; set; }
    }
}
