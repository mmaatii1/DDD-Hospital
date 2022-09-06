using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Interfaces;

namespace PatientManagement.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PatientManagementContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(PatientManagementContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);
            var deletedEntity =  _dbSet.Remove(entityToDelete);
            await _context.SaveChangesAsync();
            return entityToDelete;
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
           var updatedEntity = _dbSet.Update(entity);
           await _context.SaveChangesAsync();
           return Task.FromResult(updatedEntity).Result.Entity;
        }
    }
}
