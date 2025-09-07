using Opea.GestaoBiblioteca.Application.UseCases.LivroService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;
using Opea.GestaoBiblioteca.Domain.Interfaces;

namespace Opea.GestaoBiblioteca.Application.UseCases.LivroService.ObterLivroPorId
{
    public class ObterLivroPorIdHandler : IObterLivroPorIdHandler
    {
        private readonly ILivroRepository _livroRepository;
        public ObterLivroPorIdHandler(ILivroRepository livroRepository)
            => _livroRepository = livroRepository;

        public async Task<Response<LivroResponse>> Handle(ObterLivroPorIdRequest request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                return Response<LivroResponse>.Fail("Id", "Id do livro é obrigatório.");

            var livro = await _livroRepository.GetByIdAsync(request.Id);

            if (livro is null)
                return Response<LivroResponse>.Fail("Livro", "Livro não encontrado.");

            return Response<LivroResponse>.Ok(LivroResponse.ConverterEntidadeParaResponse(livro));
        }
    }
}
