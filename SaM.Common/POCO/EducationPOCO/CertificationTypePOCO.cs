using System;
using System.Collections.Generic;

namespace SaM.Common.POCO
{
    /// <summary>
    /// Система оценки для варианта аттестации [ Пятибальная \ Зачетная ]
    /// </summary>

    public class CertificationTypePOCO
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual IEnumerable<AttestationPOCO> Certifications { get; set; }
    }
}
