using System;

namespace SaM.BusinessLogic.POCO
{
    public class UserLocationPOCO
    {
        public Int32 Id { get; set; }
        public string Country { get; set;}
        public string Post { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public UserPOCO User { get; set; }
    }
}
