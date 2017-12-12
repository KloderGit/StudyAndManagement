using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    /// <summary>
    /// Раздел -  Учебный центр \ Школа управления | Программы \ Семинары
    /// </summary>
    public class Category : IDBObject, ISharedField
    {
        public Category()
        {
            Programs = new HashSet<EducationProgram>();
        }

        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public Int32 Order { get; set; }

        public virtual ICollection<EducationProgram> Programs { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }
    }
}
