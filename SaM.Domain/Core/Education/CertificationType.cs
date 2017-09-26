using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    /// <summary>
    /// Система оценки для варианта аттестации [ Пятибальная \ Зачетная ]
    /// </summary>

    public class CertificationType
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public Int32 AssessmentId { get; set; }
        public virtual Certification Assessment { get; set; }

        public DateTime? Updated { get; set; }
    }
}
