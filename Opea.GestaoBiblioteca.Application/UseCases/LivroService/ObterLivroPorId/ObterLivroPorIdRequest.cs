using MediatR;
using Opea.GestaoBiblioteca.Application.UseCases.LivroService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;

namespace Opea.GestaoBiblioteca.Application.UseCases.LivroService.ObterLivroPorId
{
    public record ObterLivroPorIdRequest(Guid Id) : IRequest<Response<LivroResponse>>;
}