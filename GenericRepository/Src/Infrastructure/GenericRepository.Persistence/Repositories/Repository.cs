using GenericRepository.Contract.Interfaces.Repositories;
using GenericRepository.Domain.Entities;
using GenericRepository.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly GenericRepositoryDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(GenericRepositoryDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }
        public async Task Delete(TEntity entity)
        {
            var currentEntity = await _dbSet.FindAsync(entity.Id);
            if (currentEntity == null)
            {
                throw new Exception("This row does not exist");
            }
            _dbSet.Remove(currentEntity);
        }

        public async Task DeleteById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Invalid Id");
            }
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            if (entities == null)
            {
                throw new Exception("There is no any row of data");
            }
            return entities;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new Exception("Invalid Id");
            }
            return entity;
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            //_dbSet.Update(entity);
            //_dbSet.Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            var currentEntity = await _dbSet.FindAsync(entity.Id);
            if (currentEntity == null)
            {
                throw new Exception("Invalid entity id");
            }
            _dbSet.Attach(currentEntity);
            _context.Entry(currentEntity).State = EntityState.Modified;
        }
    }
}
