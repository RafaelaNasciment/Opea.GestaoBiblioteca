using Microsoft.AspNetCore.Http;
using Opea.GestaoBiblioteca.Domain.Entities;
using Opea.GestaoBiblioteca.Domain.Interfaces;
using Opea.GestaoBiblioteca.Infrastructure.Context;

namespace Opea.GestaoBiblioteca.Infrastructure.Repositories
{
    public class EmprestimoRepository : RepositoryBase<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(AppDbContext context) : base(context)
        {            
        }
    }
}
