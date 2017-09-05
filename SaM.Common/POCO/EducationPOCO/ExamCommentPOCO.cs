using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.POCO
{
    /// <summary>
    /// Комментарий для экзамена
    /// </summary>
    public class ExamCommentPOCO
    {
        public Int32 Id { get; set; }
        public string Text { get; set; }

        public UserPOCO User { get; set; }

        public ExamPOCO Exam { get; set; }
    }
}
