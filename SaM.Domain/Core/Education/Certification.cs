using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{

    /// <summary>
    /// Вид Проверки \ Аттестации - [ Экзамен \ Тест \ Зачет ]
    /// </summary>
    public class Certification : ServiceItem<Certification>
    {
        public Certification()
        {
            CertificationTypes = new HashSet<Attestation>();
        }

        public Int32 Id { get; set; }
        public string Title { get; set; }
        public Int32 Order { get; set; }

        public virtual ICollection<Attestation> CertificationTypes { get; set; }

        public override bool EqualService(Certification item)
        {
            var result = Guid == item.Guid && Title == item.Title ? true : false;
            return result;
        }
    }
}
