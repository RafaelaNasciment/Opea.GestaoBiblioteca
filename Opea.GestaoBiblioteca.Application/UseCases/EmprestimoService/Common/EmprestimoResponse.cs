using Opea.GestaoBiblioteca.Domain.Enums;

namespace Opea.GestaoBiblioteca.Application.Services.EmprestimoService.Common
{
    public record EmprestimoResponse(
        Guid Id,
        DateTime DataCriacao,
        DateTime DataEmprestimo,
        DateTime? DataDevolucao,
        StatusEmprestimo StatusEmprestimo)
    {
        public static EmprestimoResponse ConverterEntidadeParaResponse(Domain.Entities.Emprestimo emprestimo)
        {
            return new EmprestimoResponse(
                emprestimo.Id,
                emprestimo.DataCriacao,
                emprestimo.DataEmprestimo,
                emprestimo.DataDevolucao,
                emprestimo.StatusEmprestimo);
        }
    }
}