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
        public Int32 Id { get; set; }
        public Guid Guid { get; set; }
        public string Title { get; set; }

        private DateTime _updated = DateTime.Today;
        public DateTime? Updated { get => _updated; set => _updated = DateTime.Today; }
    }
}
