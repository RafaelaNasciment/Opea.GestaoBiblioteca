using Microsoft.EntityFrameworkCore;
using Opea.GestaoBiblioteca.Domain.Entities;
using Opea.GestaoBiblioteca.Domain.Interfaces;
using Opea.GestaoBiblioteca.Infrastructure.Context;

namespace Opea.GestaoBiblioteca.Infrastructure.Repositories
{
    public class RepositoryBase<T> where T : EntityBase, IRepositoryBase<T>
    {
        protected AppDbContext _context;
        protected DbSet<T> _dbSet;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void AddList(IEnumerable<T> entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
