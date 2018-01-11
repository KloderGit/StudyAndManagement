using Mapster;
using Microsoft.EntityFrameworkCore;
using SaM.Common.DTO;
using SaM.Common.Infrastructure;
using SaM.DataBases.EntityFramework;
using SaM.Domain.Core;
using SaM.Domain.Core.Education;
using SaM.Services.Repository1C;
using SoapService1full;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SaM.BusinessLogic
{
    public abstract class AbstractNativeFacade<T> where T : class
    {
        ApplicationContext db = new ApplicationContext();
        DataManager1C service = new DataManager1C();
        protected DbSet<T> table;

        public AbstractNativeFacade()
        {
            table = db.Set<T>();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await table.ToListAsync();
        }

        //public async Task<IEnumerable<dynamic>> GetDTO()
        //{
        //    var query = await Get();

        //    Assembly assembly = typeof(ParentAttribute).GetTypeInfo().Assembly;
        //    var assemblyTypes = assembly.GetTypes();
        //    var dtoAttributItems = assemblyTypes.Where(tpe => tpe.GetTypeInfo().IsDefined(typeof(ParentAttribute), true));
        //    var dtoType = dtoAttributItems.FirstOrDefault(el => el.GetTypeInfo().GetCustomAttribute<ParentAttribute>().Parent == typeof(T));

        //    return query.Adapt<IEnumerable<T>>() as IEnumerable<CategoryDTO>;
        //}

        //public async Task<IEnumerable<T>> GetFromService()
        //{
        //    var query = await service.Categories.GetList();
        //    return query.Adapt<IEnumerable<T>>();
        //}

    }
}
