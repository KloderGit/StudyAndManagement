using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class EducationPlanEvents
    {
        public Int32 Id { get; set; }

        public Int32 EducationalPlanId { get; set; }
        public virtual EducationalPlan EducationalPlan { get; set; }

        public Int32 EducationalPlanOrder { get; set; }

        public Int32 EventId { get; set; }
        public virtual Event Event { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }
    }
}
