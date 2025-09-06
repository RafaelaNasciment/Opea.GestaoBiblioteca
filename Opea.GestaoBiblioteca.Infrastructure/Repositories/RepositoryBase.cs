using Microsoft.EntityFrameworkCore;
using Opea.GestaoBiblioteca.Domain.Entities;
using Opea.GestaoBiblioteca.Infrastructure.Context;

namespace Opea.GestaoBiblioteca.Infrastructure.Repositories
{
    public class RepositoryBase<T> where T : EntityBase
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
            entity.DataCriacao = DateTime.Now;
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            if (entity == null) 
                return;

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IList<T> GetAll()
            => [.. _dbSet];


        public T? GetById(Guid id)
            => _dbSet.FirstOrDefault(x => x.Id == id);


        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void AddList(IEnumerable<T> entity)
        {
            _dbSet.AddRange(entity);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

