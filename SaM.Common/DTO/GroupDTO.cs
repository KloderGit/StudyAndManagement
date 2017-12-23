using System;
using System.Collections.Generic;

namespace SaM.Common.DTO
{
    public class GroupDTO
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public ICollection<SubGroupDTO> SubGroups { get; set; }
        
    }
}
