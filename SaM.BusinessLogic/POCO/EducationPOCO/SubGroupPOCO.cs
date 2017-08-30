using System;

namespace SaM.BusinessLogic.POCO
{
    public class SubGroupPOCO
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public GroupPOCO Group { get; set; }
    }
}