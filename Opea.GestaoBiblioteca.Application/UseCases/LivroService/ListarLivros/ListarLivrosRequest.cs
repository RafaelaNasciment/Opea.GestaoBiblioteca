using MediatR;
using Opea.GestaoBiblioteca.Application.UseCases.LivroService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;

namespace Opea.GestaoBiblioteca.Application.UseCases.LivroService.ListarLivros
{
    public class ListarLivrosRequest : IRequest<Response<ListarLivroResponse>>;
}
