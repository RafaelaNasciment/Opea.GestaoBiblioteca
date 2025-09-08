using MediatR;
using Opea.GestaoBiblioteca.Application.UseCases.LivroService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;

namespace Opea.GestaoBiblioteca.Application.UseCases.LivroService.CriarLivro
{
    public interface ICriarLivroHandler : IRequestHandler<CriarLivroRequest, Response<LivroResponse>>
    { }
}