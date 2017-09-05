using System;

namespace SaM.Common.POCO
{
    /// <summary>
    /// Комментарий о пользователе. При установке отметки об отличнике и пр.
    /// </summary>
    public class UserCommentPOCO
    {
        public Int32 Id { get; set; }
        public string Text { get; set; }

        public UserPOCO User { get; set; }
    }
}
