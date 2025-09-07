using Opea.GestaoBiblioteca.Domain.Entities;

namespace Opea.GestaoBiblioteca.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IList<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task AddListAsync(IEnumerable<T> entity);
        Task DeleteAsync(Guid id);
    }
}