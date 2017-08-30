using System;

namespace SaM.BusinessLogic.POCO
{
    public class UserCardPOCO
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Number { get; set; }
        public string PassCode { get; set; }

        public UserPOCO User { get; set; }
    }
}
