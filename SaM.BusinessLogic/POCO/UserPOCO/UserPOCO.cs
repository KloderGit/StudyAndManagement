using System;
using System.Collections.Generic;

namespace SaM.BusinessLogic.POCO
{
    public class UserPOCO
    {
        public Int32 Id { get; set; }
        public string FirstName { get; set; }
        public string ParentMidleName { get; set; }
        public string LastName { get; set; }
        public Guid Guid { get; set; }
        public string Email { get; set; }

        public UserPhotoPOCO Photo { get; set; }
        public UserProfilePOCO Profile { get; set; }
        public UserLocationPOCO Location { get; set; }

        public ICollection<UserContractPOCO> Contracts { get; set; }
        public ICollection<UserCardPOCO> Cards { get; set; }
        public ICollection<UserCommentPOCO> UserComments { get; set; }
        public ICollection<ExamPOCO> Exams { get; set; }
        public ICollection<ExamCommentPOCO> ExamComments { get; set; }
    }
}
