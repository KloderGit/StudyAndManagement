using SaM.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.ServiceEntity
{
    public class EducationProgramService : ServiceItem<EducationProgramService>
    {
        public string Title { get; set; }
        public bool Active { get; set; }
        public DateTime AcceptDate { get; set; }
        public string ProgramType { get; set; }
        public string StudyType { get; set; }

        public CategoryService Category { get; set; }

        public EducationTypeService EducationType { get; set; }
    }
}
