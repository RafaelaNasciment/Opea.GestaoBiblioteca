using Opea.GestaoBiblioteca.Domain.Entities;
using System.Linq.Expressions;

namespace Opea.GestaoBiblioteca.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IList<T>> GetAllAsync(CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes);

        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes);

        Task AddAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);

        Task AddListAsync(IEnumerable<T> entity, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}