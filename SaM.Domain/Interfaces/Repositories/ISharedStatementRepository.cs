﻿using SaM.Domain.Core.Education;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface ISharedStatementRepository<T> : ICommonRepository<T> where T : class
    {
    }
}