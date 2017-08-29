using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.User
{
    public class UserProfile
    {
        public Int32 Id { get; set; }
        public DateTime Birthday { get; set; }
        public string WWW { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Skype { get; set; }
        public bool Excellent { get; set; }

        public Int32 UserId { get; set; }
        public virtual User User { get; set; }
    }
}
