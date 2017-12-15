using SaM.Domain.Core;
using SaM.Domain.Core.Education;
using SaM.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core
{
    public class GuidComparer : IEqualityComparer<ServiceItem>
    {
        public bool Equals(ServiceItem x, ServiceItem y)
        {            
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null)) return false;

            return x.Guid == y.Guid;
        }

        public int GetHashCode(ServiceItem item)
        {
            if (Object.ReferenceEquals(item, null)) return 0;

            var hash = 19;
            hash = hash * 37 + item.Guid.GetHashCode();
            return hash;
        }
    }
}
