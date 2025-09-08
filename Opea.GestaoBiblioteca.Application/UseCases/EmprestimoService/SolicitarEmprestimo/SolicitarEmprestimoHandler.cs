using Opea.GestaoBiblioteca.Application.Services.EmprestimoService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;
using Opea.GestaoBiblioteca.Domain.Interfaces;

namespace Opea.GestaoBiblioteca.Application.UseCases.EmprestimoService.SolicitarEmprestimo
{
    public class SolicitarEmprestimoHandler : ISolicitarEmprestimoHandler
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly ILivroRepository _livroRepository;

        public SolicitarEmprestimoHandler(IEmprestimoRepository emprestimoRepository, ILivroRepository livroRepository)
        {
            _emprestimoRepository = emprestimoRepository;
            _livroRepository = livroRepository;
        }

        public async Task<Response<EmprestimoResponse>> Handle(SolicitarEmprestimoRequest request, CancellationToken cancellationToken)
        {
            if (request.LivroId == Guid.Empty)
                return Response<EmprestimoResponse>.Fail("Id", "Id do livro é obrigatório.");

            var livro = await _livroRepository.GetByIdAsync(request.LivroId, cancellationToken, x => x.Emprestimos);

            if (livro is null)
                return Response<EmprestimoResponse>.Fail("Livro", "Livro não encontrado.");

            if (livro.QuantidadeDisponivel <= 0)
                return Response<EmprestimoResponse>.Fail("Livro", "Livro sem quantidade disponível para empréstimo.");

            var emprestimo = new Domain.Entities.Emprestimo(
                id: null,
                dataCriacao: null,
                livroId: livro.Id
            );

            if (!emprestimo.IsValid)
                return Response<EmprestimoResponse>.Fail(emprestimo.Notifications);

            livro.AdicionarEmprestimo(emprestimo);

            await _emprestimoRepository.AddAsync(emprestimo, cancellationToken);

            return Response<EmprestimoResponse>.Ok(data: EmprestimoResponse.ConverterEntidadeParaResponse(emprestimo));
        }
    }
}