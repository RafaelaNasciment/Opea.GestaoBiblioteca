using Microsoft.EntityFrameworkCore;
using Opea.GestaoBiblioteca.Domain.Entities;
using Opea.GestaoBiblioteca.Domain.Interfaces;
using Opea.GestaoBiblioteca.Infrastructure.Context;
using System.Linq.Expressions;

namespace Opea.GestaoBiblioteca.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected AppDbContext _context;
        protected DbSet<T> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            _context.SaveChanges();
        }

        public async Task AddListAsync(IEnumerable<T> entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddRangeAsync(entity, cancellationToken);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity is null)
                return;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync(CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes)
        {
            var query = includes?.Aggregate(_dbSet.AsQueryable(), (current, include)
                => current.Include(include));
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken, params Expression<Func<T, object>>[] includes)
        {
            var query = includes?.Aggregate(_dbSet.AsQueryable(), (current, include)
                => current.Include(include));

            return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}