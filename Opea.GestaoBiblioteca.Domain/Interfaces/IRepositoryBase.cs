using Opea.GestaoBiblioteca.Domain.Entities;

namespace Opea.GestaoBiblioteca.Domain.Interfaces
{
    public interface IRepositoryBase<T> : IDisposable where T : EntityBase
    {
        IList<T> GetAll();
        T? GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void AddList(IEnumerable<T> entity);
        void Delete(Guid id);
    }
}