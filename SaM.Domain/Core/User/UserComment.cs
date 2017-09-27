using SaM.Domain.Interfaces;
using System;

namespace SaM.Domain.Core.User
{
    /// <summary>
    /// Комментарий о пользователе. При установке отметки об отличнике и пр.
    /// </summary>
    public class UserComment : IDBObject
    {
        public Int32 Id { get; set; }
        public string Text { get; set; }

        public Int32 UserId { get; set; }
        public virtual User User { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }
    }
}
