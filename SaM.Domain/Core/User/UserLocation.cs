﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.User
{
    public class UserLocation
    {
        public Int32 Id { get; set; }
        public string Country { get; set;}
        public string Post { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public Int32 UserId { get; set; }
        public virtual User User { get; set; }
    }
}
