using Opea.GestaoBiblioteca.Application.Services.EmprestimoService.Common;
using Opea.GestaoBiblioteca.Domain.Entities;

namespace Opea.GestaoBiblioteca.Application.UseCases.LivroService.Common
{   
    public record LivroResponse(
        Guid Id,
        string Titulo,
        string Autor,
        int AnoPublicacao,
        int QuantidadeDisponivel,
        List<EmprestimoResponse> Emprestimos)
    {
        public static LivroResponse ConverterEntidadeParaResponse(Livro livro)
        {
            var emprestimosResponse = livro.Emprestimos?
                .Select(EmprestimoResponse.ConverterEntidadeParaResponse)
                .ToList() ?? [];

            return new LivroResponse(
                Id: livro.Id,
                Titulo: livro.Titulo,
                Autor: livro.Autor,
                AnoPublicacao: livro.AnoPublicacao,
                QuantidadeDisponivel: livro.QuantidadeDisponivel,
                Emprestimos: emprestimosResponse);
        }
    }
}
