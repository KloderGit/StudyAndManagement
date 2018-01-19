using SaM.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Common.ServiceEntity
{
    public class CategoryService : ServiceItem<CategoryService>
    {
        public string Title { get; set; }
    }
}
