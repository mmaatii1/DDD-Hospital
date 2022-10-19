using Microsoft.EntityFrameworkCore;
using PatientManagement.Core.Interfaces;
using System.Linq.Expressions;
using PatientManagement.Core.Validators.Exceptions;

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
            
            if (entityToDelete is null)
            {
                var getEntityType = _dbSet.EntityType;
                var entityName = getEntityType.Name.ToString().Split('.').Last();
                throw new EntityNotFoundException(entityName);
            }
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
            var entity =  await _dbSet.FindAsync(id);
            if (entity is null)
            {
                var getEntityType = _dbSet.EntityType;
                var entityName = getEntityType.Name.ToString().Split('.').Last();
                throw new EntityNotFoundException(entityName);
            }

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        { 
            //todo: this is weird, i had to do this like that due to the fact that if im checking for for 
            //todo:FindEntity i have detached entity error. Maybe it could be done better
            var updatedEntity = _dbSet.Update(entity);
           try
           {
               await _context.SaveChangesAsync();
               return entity;
           }
           catch (Exception exception)
           {
               if (exception.Message.Contains("The database operation was expected to affect 1 row(s), but actually affected 0 row(s);") || exception.Message.Contains("Attempted to update or delete an entity that does not exist in the store"))
               {
                   var entityName = updatedEntity.GetType().ToString().Split('.').Last();
                   throw new EntityNotFoundException(entityName);
               }
               else
               {
                   throw new Exception(exception.Message);
               }
           }
        }

        public IQueryable<TEntity> GetWithEntity<TProperty, TPropertyTwo>(Expression<Func<TEntity, TProperty>> includeEntityOne, Expression<Func<TEntity, TPropertyTwo>>? includeEntityTwo)
        {
            return _dbSet.Include(includeEntityOne).Include(includeEntityTwo);
        }
    }
}
