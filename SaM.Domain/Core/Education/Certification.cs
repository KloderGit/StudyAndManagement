using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{

    /// <summary>
    /// Вид Проверки \ Аттестации - [ Экзамен \ Тест \ Зачет ]
    /// </summary>
    public class Certification
    {
        public Certification()
        {
            CertificationTypeList = new HashSet<CertificationType>();
        }

        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<CertificationType> CertificationTypeList { get; set; }

        public DateTime? Updated { get; set; }
    }
}
