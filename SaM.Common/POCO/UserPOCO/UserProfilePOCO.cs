using System;

namespace SaM.Common.POCO
{
    public class UserProfilePOCO
    {
        public Int32 Id { get; set; }
        public DateTime Birthday { get; set; }
        public string WWW { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public bool Excellent { get; set; }

        public UserPOCO User { get; set; }
    }
}
