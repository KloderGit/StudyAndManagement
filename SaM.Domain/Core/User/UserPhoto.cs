using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.User
{
    public class UserPhoto
    {
        public Int32 Id { get; set; }
        public string Url { get; set; }

        public Int32 UserId { get; set; }
        public virtual User User { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }
    }
}
