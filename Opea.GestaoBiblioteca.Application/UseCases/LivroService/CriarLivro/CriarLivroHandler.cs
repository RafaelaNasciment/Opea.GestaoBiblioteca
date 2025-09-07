using Opea.GestaoBiblioteca.Application.UseCases.LivroService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;
using Opea.GestaoBiblioteca.Domain.Entities;
using Opea.GestaoBiblioteca.Domain.Interfaces;

namespace Opea.GestaoBiblioteca.Application.UseCases.LivroService.CriarLivro
{
    public class CriarLivroHandler : ICriarLivroHandler
    {
        private readonly ILivroRepository _livroRepository;
        public CriarLivroHandler(ILivroRepository livroRepository)        
            => _livroRepository = livroRepository;
        
        public async Task<Response<LivroResponse>> Handle(CriarLivroRequest request, CancellationToken cancellationToken)
        {

            var livro = new Livro(
                id: null,
                dataCriacao: null,
                titulo: request.Titulo,
                autor: request.Autor,
                anoPublicacao: request.AnoPublicacao,
                quantidadeDisponivel: request.QuantidadeDisponivel
            );
    
            if (!livro.IsValid)            
                return Response<LivroResponse>.Fail(livro.Notifications);            

            await _livroRepository.AddAsync(livro);

            return Response<LivroResponse>.Ok(data: LivroResponse.ConverterEntidadeParaResponse(livro));
        }
    }
}
