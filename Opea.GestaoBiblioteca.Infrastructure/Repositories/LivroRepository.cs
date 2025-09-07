using Opea.GestaoBiblioteca.Domain.Entities;
using Opea.GestaoBiblioteca.Domain.Interfaces;
using Opea.GestaoBiblioteca.Infrastructure.Context;

namespace Opea.GestaoBiblioteca.Infrastructure.Repositories
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        public LivroRepository(AppDbContext context) : base(context)
        {
        }
    }
}
