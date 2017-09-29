using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SaM.Common.DTO
{
    public class EducationProgramDTO
    {
        public string Guid { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public string AcceptDate { get; set; }
        public string ProgramType { get; set; }
        public string StudyType { get; set; }

        public CategoryDTO Category { get; set; }

        public EducationTypeDTO EducationType { get; set; }
    }
}