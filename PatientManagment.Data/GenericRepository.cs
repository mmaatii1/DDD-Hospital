using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Interfaces;
using System.Linq.Expressions;

namespace PatientManagement.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly PatientManagementContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(PatientManagementContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            _dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();
            return entityToDelete;
        }

        public IQueryable<TEntity> GetWithEntity<TProperty>(Expression<Func<TEntity, TProperty>> includeEntityOne)
        {
            return _dbSet.Include(includeEntityOne);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
           _dbSet.Update(entity);
           await _context.SaveChangesAsync();
           return entity;
        }

        public IQueryable<TEntity> GetWithEntity<TProperty, TPropertyTwo>(Expression<Func<TEntity, TProperty>> includeEntityOne, Expression<Func<TEntity, TPropertyTwo>>? includeEntityTwo)
        {
            return _dbSet.Include(includeEntityOne).Include(includeEntityTwo);
        }
    }
}
