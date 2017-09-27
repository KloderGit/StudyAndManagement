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
            EducationPlanList = new HashSet<EducationPlanEvents>();
        }

        public Int32 Id { get; set; }
        public DateTime Date { get; set; }
        public Int32? StudentsCount { get; set; }

        public virtual ICollection<EducationPlanEvents> EducationPlanList { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }
    }
}
