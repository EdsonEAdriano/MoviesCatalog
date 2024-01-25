using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.Domain.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetAsync(int? id);

    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> RemoveAsync(T entity);
}