using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface ICommonRepository<T>
    {
        IQueryable<T> GetList();
    }
}