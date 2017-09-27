using SaM.Domain.Interfaces;
using System;

namespace SaM.Common.DTO
{
    public class CategoryDTO : ISharedField
    {
        public string Guid { get; set; }
        public string Title { get; set; }
    }
}
