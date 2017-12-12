using SaM.Domain.Interfaces;
using System;

namespace SaM.Common.DTO
{
    public class CategoryDTO
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public Int32 Order { get; set; }
    }
}
