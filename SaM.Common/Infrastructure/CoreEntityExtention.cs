using SaM.Common.DTO;
using SaM.Domain.Core;
using SaM.Domain.Core.Education;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SaM.Common.Infrastructure
{
    public static class CoreEntityExtention
    {
        public static string GetDTO1(this ServiceItem instance)
        {
            Type t = instance.GetType();
            Assembly assembly = typeof(ParentAttribute).GetTypeInfo().Assembly;
            var assemblyTypes = assembly.GetTypes();
            var dtoAttributItems = assemblyTypes.Where( tpe => tpe.GetTypeInfo().IsDefined( typeof(ParentAttribute), true));
            var dtoType = dtoAttributItems.FirstOrDefault(el => el.GetTypeInfo().GetCustomAttribute<ParentAttribute>().Parent == t);


            return instance.GetType().ToString();
        }
    }

}
