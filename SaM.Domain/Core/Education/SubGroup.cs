using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class SubGroup
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public Int32 GroupId { get; set; }
        public virtual Group Group { get; set; }

        public DateTime? Updated { get; set; }
    }
}