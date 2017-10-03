using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    public class Attestation : IDBObject
    {
        public Int32 Id { get; set; }

        public Int32 CertificationId { get; set; }
        public virtual Certification Certification { get; set; }

        public Int32 CertificationTypeId { get; set; }
        public virtual CertificationType CertificationType { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }
    }
}
