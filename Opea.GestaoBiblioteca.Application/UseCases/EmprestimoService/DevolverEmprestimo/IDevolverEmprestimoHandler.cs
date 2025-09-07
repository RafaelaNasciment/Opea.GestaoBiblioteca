using MediatR;
using Opea.GestaoBiblioteca.Application.Services.EmprestimoService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;

namespace Opea.GestaoBiblioteca.Application.UseCases.EmprestimoService.DevolverEmprestimo
{
    public interface IDevolverEmprestimoHandler : IRequestHandler<DevolverEmprestimoRequest, Response<EmprestimoResponse>> { }
}
