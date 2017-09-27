using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class Subject : IDBObject, ISharedField
    {
        public Subject()
        {
            EducationalPlanList = new HashSet<EducationalPlan>();
        }

        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<EducationalPlan> EducationalPlanList { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }
    }
}
