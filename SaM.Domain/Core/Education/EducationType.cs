using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core.Education
{
    /// <summary>
    /// Очное \ Заочное
    /// </summary>
    public class EducationType : IDBObject, ISharedField
    {
        public EducationType()
        {
            updated = DateTime.Today;
        }

        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public Int32 Order { get; set; }

        private DateTime updated;
        public DateTime? Updated { get => updated; }
    }
}
