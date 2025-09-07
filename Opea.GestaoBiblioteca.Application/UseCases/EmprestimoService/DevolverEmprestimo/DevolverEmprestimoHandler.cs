using Opea.GestaoBiblioteca.Application.Services.EmprestimoService.Common;
using Opea.GestaoBiblioteca.Application.UseCases.Responses;
using Opea.GestaoBiblioteca.Domain.Interfaces;

namespace Opea.GestaoBiblioteca.Application.UseCases.EmprestimoService.DevolverEmprestimo
{
    public class DevolverEmprestimoHandler : IDevolverEmprestimoHandler
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public DevolverEmprestimoHandler(IEmprestimoRepository emprestimoRepository)      
            => _emprestimoRepository = emprestimoRepository;       
            
        
        public async Task<Response<EmprestimoResponse>> Handle(DevolverEmprestimoRequest request, CancellationToken cancellationToken)
        {
            if (request.LivroId == Guid.Empty)
                return Response<EmprestimoResponse>.Fail("Id", "Id do livro é obrigatório.");

            if (request.EmprestimoId == Guid.Empty)
                return Response<EmprestimoResponse>.Fail("Id", "Id do empréstimo é obrigatório.");

            var emprestimo = await _emprestimoRepository.GetByIdAsync(
                request.EmprestimoId, 
                cancellationToken,
                x => x.Livro);

            if (emprestimo is null)
                return Response<EmprestimoResponse>.Fail("Empréstimo", "Empréstimo não encontrado.");

            if (emprestimo.LivroId != request.LivroId)
                return Response<EmprestimoResponse>.Fail("Empréstimo", "Empréstimo não pertence ao livro informado.");

            if (emprestimo.StatusEmprestimo == Domain.Enums.StatusEmprestimo.Devolvido)
                return Response<EmprestimoResponse>.Fail("Empréstimo", "Empréstimo já foi devolvido.");

            emprestimo.DevolverEmprestimo();

            if(!emprestimo.IsValid)
                return Response<EmprestimoResponse>.Fail(emprestimo.Notifications); 

            await _emprestimoRepository.UpdateAsync(emprestimo, cancellationToken);

            return Response<EmprestimoResponse>.Ok(data: EmprestimoResponse.ConverterEntidadeParaResponse(emprestimo));
        }
    }
}
