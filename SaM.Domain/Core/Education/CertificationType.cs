using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    /// <summary>
    /// Система оценки для варианта аттестации [ Пятибальная \ Зачетная ]
    /// </summary>

    public class CertificationType : ServiceItem<CertificationType>
    {
        public CertificationType()
        {
            Certifications = new HashSet<Attestation>();
        }

        public Int32 Id { get; set; }
        //public Guid Guid { get; set; }
        public string Title { get; set; }
        public Int32 Order { get; set; }

        public virtual ICollection<Attestation> Certifications { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }

        //public override bool EqualService(CertificationType item)
        //{
        //    var result = Guid == item.Guid && Title == item.Title ? true : false;
        //    return result;
        //}
    }
}
