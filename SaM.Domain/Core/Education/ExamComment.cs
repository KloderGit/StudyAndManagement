﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    /// <summary>
    /// Комментарий для экзамена
    /// </summary>
    public class ExamComment
    {
        public Int32 Id { get; set; }
        public string Text { get; set; }

        public Int32 UserId { get; set; }
        public virtual Core.User.User User { get; set; }

        public Int32 ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        public DateTime? Updated { get; set; }
    }
}
