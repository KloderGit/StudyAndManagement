using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace SaM.Domain.Core.Education
{
    public class Statement 
    {
        public Statement()
        {
            updated = DateTime.Today;
        }

        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public Int32 EducationProgramId { get; set; }
        public virtual EducationProgram EducationProgram { get; set; }

        public Int32? GroupId { get; set; }
        public virtual Group Group { get; set; }

        public Int32 EventId { get; set; }
        public virtual Event Event { get; set; }

        private DateTime updated;
        public DateTime? Updated { get => updated; }
    }
}
