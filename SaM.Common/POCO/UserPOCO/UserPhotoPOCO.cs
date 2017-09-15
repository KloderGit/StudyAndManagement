using System;

namespace SaM.Common.POCO
{
    public class UserPhotoPOCO
    {
        public Int32 Id { get; set; }
        public string Url { get; set; }

        public UserPOCO User { get; set; }
    }
}
