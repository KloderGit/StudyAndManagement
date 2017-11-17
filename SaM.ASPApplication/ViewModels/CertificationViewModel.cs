using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.ASPApplication.ViewModels
{
    public class CertificationViewModel
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual IEnumerable<CertificationTypeViewModel> CertificationsTypes { get; set; }
    }
}
