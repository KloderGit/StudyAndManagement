﻿using SaM.Domain.Core.User;

namespace SaM.Domain.Interfaces.Repositories
{
    public interface IUserContractRepository<T> : ICommonRepository<T> where T : class
    {
    }
}
