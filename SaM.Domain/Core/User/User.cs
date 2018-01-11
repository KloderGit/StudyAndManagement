using System;
using System.Collections.Generic;
using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces;
using System.Reflection;
using System.Linq;

namespace SaM.Domain.Core.User
{
    public class User : ServiceItem<User>
    {
        public User()
        {
            Contracts = new HashSet<UserContract>();
            Cards = new HashSet<UserCard>();
            UserComments = new HashSet<UserComment>();
            ExamComments = new HashSet<ExamComment>();
            Exams = new HashSet<Exam>();
        }

        [PropertyNotForEqual]
        public Int32 Id { get; set; }

        public string FirstName { get; set; }
        public string ParentMidleName { get; set; }
        public string LastName { get; set; }
        //public Guid Guid { get; set; }
        public string Email { get; set; }

        [PropertyNotForEqual]
        public Int32 Order { get; set; }

        [PropertyNotForEqual]
        public virtual UserPhoto Photo { get; set; }

        public virtual UserProfile Profile { get; set; }
        public virtual UserLocation Location { get; set; }

        [PropertyNotForEqual]
        public virtual ICollection<UserContract> Contracts { get; set; }

        public virtual ICollection<UserCard> Cards { get; set; }

        [PropertyNotForEqual]
        public virtual ICollection<UserComment> UserComments { get; set; }

        [PropertyNotForEqual]
        public virtual ICollection<Exam> Exams { get; set; }

        [PropertyNotForEqual]
        public virtual ICollection<ExamComment> ExamComments { get; set; }

        private DateTime _updated = DateTime.Today;

        [PropertyNotForEqual]
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }

        public override bool EqualService(User item)
        {
            var result = Guid == item.Guid 
                && FirstName == item.FirstName
                && ParentMidleName == item.ParentMidleName
                && LastName == item.LastName
                && Email == item.Email
                ? true : false;
            return result;
        }

        public static IEnumerable<PropertyInfo> GetValueObjectProperties()
        {
            var properties = typeof(User).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            return properties.Where(prop => prop.GetCustomAttribute(typeof(PropertyNotForEqualAttribute)) == null);
        }

    }
}
