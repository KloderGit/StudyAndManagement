using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class Group
    {
        public Group()
        {
            SubGroupList = new HashSet<SubGroup>();
        }

        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public Int32 ProgramId { get; set; }
        public virtual EducationProgram Program { get; set; }

        public virtual ICollection<SubGroup> SubGroupList { get; set; }
        
    }
}
