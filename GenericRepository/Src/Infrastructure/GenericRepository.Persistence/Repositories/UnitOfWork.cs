using GenericRepository.Contract.Interfaces.Repositories;
using GenericRepository.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GenericRepositoryDbContext _context;

        public UnitOfWork(GenericRepositoryDbContext context)
        {
            this._context = context;
        }
        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
