using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{

    /// <summary>
    /// Вид Проверки \ Аттестации - [ Экзамен \ Тест \ Зачет ]
    /// </summary>
    public class Certification : IDBObject
    {
        public Certification()
        {
            CertificationTypeList = new HashSet<CertificationType>();
        }

        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<CertificationType> CertificationTypeList { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }
    }
}
