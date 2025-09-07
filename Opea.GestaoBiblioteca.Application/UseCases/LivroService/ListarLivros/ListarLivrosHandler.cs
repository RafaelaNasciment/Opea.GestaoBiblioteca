using Opea.GestaoBiblioteca.Application.UseCases.LivroService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;
using Opea.GestaoBiblioteca.Domain.Interfaces;

namespace Opea.GestaoBiblioteca.Application.UseCases.LivroService.ListarLivros
{
    public class ListarLivrosHandler : IListarLivrosHandler
    {
        private readonly ILivroRepository _livroRepository;
        public ListarLivrosHandler(ILivroRepository livroRepository)
            => _livroRepository = livroRepository;
        public async  Task<Response<ListarLivroResponse>> Handle(ListarLivrosRequest request, CancellationToken cancellationToken)
        {
            var livros = await _livroRepository.GetAllAsync(
                cancellationToken,
                x => x.Emprestimos);

            if (livros is null || !livros.Any())
                return Response<ListarLivroResponse>.Ok(new ListarLivroResponse([]));

            var livrosResponse = livros
                .Select(LivroResponse.ConverterEntidadeParaResponse)
                .ToList();

            return Response<ListarLivroResponse>.Ok(new ListarLivroResponse(livrosResponse));
        }
    }
}
