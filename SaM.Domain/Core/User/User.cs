using System;
using System.Collections.Generic;
using SaM.Domain.Core.Education;

namespace SaM.Domain.Core.User
{
    public class User
    {
        public User()
        {
            Contracts = new HashSet<UserContract>();
            Cards = new HashSet<UserCard>();
            UserComments = new HashSet<UserComment>();
            ExamComments = new HashSet<ExamComment>();
            Exams = new HashSet<Exam>();
        }

        public Int32 Id { get; set; }
        public string FirstName { get; set; }
        public string ParentMidleName { get; set; }
        public string LastName { get; set; }
        public Guid Guid { get; set; }
        public string Email { get; set; }

        public virtual UserPhoto Photo { get; set; }
        public virtual UserProfile Profile { get; set; }
        public virtual UserLocation Location { get; set; }

        public virtual ICollection<UserContract> Contracts { get; set; }
        public virtual ICollection<UserCard> Cards { get; set; }
        public virtual ICollection<UserComment> UserComments { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<ExamComment> ExamComments { get; set; }
    }
}
