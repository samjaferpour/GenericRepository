﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Contract.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitChangesAsync();
    }
}
