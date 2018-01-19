using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class Subject : ServiceItem<Subject>
    {
        public Subject()
        {
            EducationalPlanList = new HashSet<EducationalPlan>();
        }

        public Int32 Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<EducationalPlan> EducationalPlanList { get; set; }
    }
}
