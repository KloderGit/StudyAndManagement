using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.Infrastructure
{
    /// <summary>
    /// Указывает классу DTO на класс для которого это DTO
    /// Атррибут должен располагаться в одной assembly с DTO объектами
    /// </summary>
    public sealed class ParentAttribute : Attribute
    {
        public Type Parent { get; set; }

        public ParentAttribute()
        { }

        public ParentAttribute(Type name)
        {
            Parent = name;
        }
    }
}
