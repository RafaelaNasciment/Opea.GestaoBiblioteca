using MediatR;
using Opea.GestaoBiblioteca.Application.UseCases.LivroService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;

namespace Opea.GestaoBiblioteca.Application.UseCases.LivroService.CriarLivro
{
    public record CriarLivroRequest(string Titulo, string Autor, int AnoPublicacao, int QuantidadeDisponivel)
        : IRequest<Response<LivroResponse>>;
}