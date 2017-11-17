using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaM.ASPApplication.ViewModels
{
    public class EducationProgramViewModel
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public string ProgramType { get; set; }
        public string StudyType { get; set; }

        public CategoryViewModel Category { get; set; }

        public EducationTypeViewModel EducationType { get; set; }

        public ICollection<SubjectViewModel> SubjectList { get; set; }
    }
}
