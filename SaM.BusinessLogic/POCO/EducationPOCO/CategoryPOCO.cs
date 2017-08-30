using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.BusinessLogic.POCO
{
    /// <summary>
    /// Раздел -  Учебный центр \ Школа управления | Программы \ Семинары
    /// </summary>
    public class CategoryPOCO
    {
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        public ICollection<EducationProgramPOCO> Programs { get; set; }
    }
}
