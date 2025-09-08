using MediatR;
using Opea.GestaoBiblioteca.Application.Services.EmprestimoService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;

namespace Opea.GestaoBiblioteca.Application.UseCases.EmprestimoService.SolicitarEmprestimo
{
    public record SolicitarEmprestimoRequest(Guid LivroId) : IRequest<Response<EmprestimoResponse>>;
}