using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Interfaces
{
    public interface IDBObject
    {
        Int32 Id { get; set; }
        DateTime? Updated { get; set; }
    }
}
