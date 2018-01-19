using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SaM.Domain.Core.Education
{
    /// <summary>
    /// Раздел -  Учебный центр \ Школа управления | Программы \ Семинары
    /// </summary>
    public class Category : ServiceItem<Category>
    {
        public Category()
        {
            Programs = new HashSet<EducationProgram>();
        }

        public Int32 Id { get; set; }
        public string Title { get; set; }
        public Int32 Order { get; set; }

        public virtual ICollection<EducationProgram> Programs { get; set; }

        //public override bool EqualService(Category item)
        //{
        //    var result = Guid == item.Guid && Title == item.Title ? true : false;
        //    return result;
        //}

    }
}
