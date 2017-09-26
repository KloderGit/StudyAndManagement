using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.User
{
    public class UserCard
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Number { get; set; }
        public string PassCode { get; set; }

        public Int32 UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime? Updated { get; set; }
    }
}
