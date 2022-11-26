using System.Linq.Expressions;
using PatientManagement.Core.Entities;

namespace PatientManagement.Core.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
        IEnumerable<TEntity> GetWithEntity<TProperty>(Expression<Func<TEntity, TProperty>> includeEntityOne);

        IEnumerable<TEntity> GetWithEntity<TProperty, TPropertyTwo>(
            Expression<Func<TEntity, TProperty>> includeEntityOne,
            Expression<Func<TEntity, TPropertyTwo>>? includeEntityTwo);
    }
}
