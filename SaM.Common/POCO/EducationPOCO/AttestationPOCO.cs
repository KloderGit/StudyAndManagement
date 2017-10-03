using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.POCO
{
    public class AttestationPOCO
    {
        public Int32 Id { get; set; }

        public CertificationPOCO Certification { get; set; }

        public CertificationTypePOCO CertificationType { get; set; }

    }
}
