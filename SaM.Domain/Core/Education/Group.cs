using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class Group : ServiceItem<Group>
    {
        public Group()
        {
            SubGroupList = new HashSet<SubGroup>();
        }

        public Int32 Id { get; set; }
        //public Guid Guid { get; set; }
        public string Title { get; set; }
        public Int32 Order { get; set; }

        public Int32 ProgramId { get; set; }
        public virtual EducationProgram Program { get; set; }

        public virtual ICollection<SubGroup> SubGroupList { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }

        public override bool EqualService(Group item)
        {
            var result = Guid == item.Guid && Title == item.Title ? true : false;
            return result;
        }
    }
}
