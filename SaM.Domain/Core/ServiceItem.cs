using SaM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaM.Domain.Core
{
    public abstract class ServiceItem : IServiceItem
    {
        public Guid Guid { get; set; }
    }

    public abstract class ServiceItem<T> : ServiceItem
    {
        public abstract bool EqualService(T item);
    }
}