using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.ASPApplication.Areas.Admin.ViewModels
{
    public class SubjectViewModel
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Certification { get; set; }
        public Int32? Duration { get; set; }
    }
}
