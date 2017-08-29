using System;

namespace SaM.Domain.Core.User
{
    /// <summary>
    /// Комментарий о пользователе. При установке отметки об отличнике и пр.
    /// </summary>
    public class UserComment
    {
        public Int32 Id { get; set; }
        public string Text { get; set; }

        public Int32 UserId { get; set; }
        public virtual User User { get; set; }
    }
}
