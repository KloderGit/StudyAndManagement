using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    /// <summary>
    /// Раздел -  Учебный центр \ Школа управления | Программы \ Семинары
    /// </summary>
    public class Category
    {
        public Category()
        {
            Programs = new HashSet<EducationProgram>();
        }

        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public virtual ICollection<EducationProgram> Programs { get; set; }

        public DateTime? Updated { get; set; }
    }
}
