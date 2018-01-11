using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public sealed class PropertyNotForEqualAttribute : Attribute
    {
        public PropertyNotForEqualAttribute()
        { }
    }
}
