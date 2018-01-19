using SaM.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SaM.Domain.Core
{
    public abstract class ServiceItem : IServiceItem
    {
        public Guid Guid { get; set; }
    }

    public abstract class ServiceItem<T> : ServiceItem 
                                 where T: class
    {
        protected static IEnumerable<PropertyInfo> properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        public bool Equals(T obj)
        {
            return this.GetHashCode() == obj.GetHashCode();
        }



        public bool Equals(ServiceItem obj)
        {
            return this.GetHashCode() == GetHashCode(obj);
        }

        public override int GetHashCode()
        {
            var hash = 19;

            foreach (var item in GetValueObjectProperties())
            {
                var value = item.GetValue(this);
                if (value != null) hash = hash * 37 + value.GetHashCode();
            }

            return hash;
        }

        protected int GetHashCode(ServiceItem obj)
        {
            var hash = 19;

            var fields = ServiceItem<T>.GetValueObjectProperties();

            foreach (var item in fields)
            {
                var value = obj.GetType().GetProperty(item.Name).GetValue(obj, null);

                if (value != null) hash = hash * 37 + value.GetHashCode();
            }

            return hash;
        }



        protected static IEnumerable<PropertyInfo> GetValueObjectProperties()
        {
            var result = properties?.Where(prop => ((!(prop.GetAccessors()[0].IsVirtual && !prop.GetAccessors()[0].IsFinal)
                                                      && !typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                                                     || typeof(String).IsAssignableFrom(prop.PropertyType)
                                                     || prop.GetCustomAttribute(typeof(PropertyAddForEqualAttribute)) != null))
                                    .Where(prop => prop.GetCustomAttribute(typeof(PropertyNotForEqualAttribute)) == null);

            return result;
        }

    }


}