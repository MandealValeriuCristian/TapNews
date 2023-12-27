using API.Helpers;
using System.Linq.Expressions;

namespace API.Data.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetAsync(int id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

    void Add(TEntity entity);
    void Remove(TEntity entity);
}
