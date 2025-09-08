using MediatR;
using Opea.GestaoBiblioteca.Application.UseCases.LivroService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;

namespace Opea.GestaoBiblioteca.Application.UseCases.LivroService.ObterLivroPorId
{
    public interface IObterLivroPorIdHandler : IRequestHandler<ObterLivroPorIdRequest, Response<LivroResponse>>
    {
    }
}