using Moq;
using Opea.GestaoBiblioteca.Application.UseCases.EmprestimoService.DevolverEmprestimo;
using Opea.GestaoBiblioteca.Domain.Entities;
using Opea.GestaoBiblioteca.Domain.Enums;
using Opea.GestaoBiblioteca.Domain.Interfaces;
using System.Linq.Expressions;
using Xunit;

namespace Opea.GestaoBiblioteca.Tests.Application.UseCases.EmprestimoService
{
    public class DevolverEmprestimoTests
    {
        private readonly Mock<IEmprestimoRepository> _repo;
        private readonly IDevolverEmprestimoHandler _handler;

        public DevolverEmprestimoTests()
        {
            _repo = new Mock<IEmprestimoRepository>(MockBehavior.Strict);
            _handler = new DevolverEmprestimoHandler(_repo.Object);
        }

        [Fact(DisplayName = "Devolver empréstimo ativo deve marcar como devolvido")]
        public async Task DevolverEmprestimoComSucesso()
        {
            // arrange
            var emprestimoId = Guid.NewGuid();
            var livroId = Guid.NewGuid();
            var livro = new Livro(livroId, null, "Titulo informado", "Autor informado", 2000, 1);

            var emprestimo = new Emprestimo
            {
                Id = emprestimoId,
                LivroId = livroId,
                DataEmprestimo = new DateTime(2025, 9, 1),
                StatusEmprestimo = StatusEmprestimo.Ativo,
                Livro = livro
            };

            var req = new DevolverEmprestimoRequest(livroId, emprestimoId);

            _repo.Setup(r => r.GetByIdAsync(
                            emprestimoId,
                            It.IsAny<CancellationToken>(),
                            It.IsAny<Expression<Func<Emprestimo, object>>[]>()))
                 .ReturnsAsync(emprestimo);

            _repo.Setup(r => r.UpdateAsync(It.IsAny<Emprestimo>(), It.IsAny<CancellationToken>()))
                 .Returns(Task.CompletedTask);

            // act
            var result = await _handler.Handle(req, CancellationToken.None);

            // assert
            Assert.True(result.Success);
            Assert.NotNull(result.Data);
            Assert.NotNull(result.Data!.DataDevolucao);
            Assert.Equal(StatusEmprestimo.Devolvido, result.Data.StatusEmprestimo);

            _repo.Verify(r => r.GetByIdAsync(
                              emprestimoId,
                              It.IsAny<CancellationToken>(),
                              It.IsAny<Expression<Func<Emprestimo, object>>[]>()), Times.Once);
            _repo.Verify(r => r.UpdateAsync(It.IsAny<Emprestimo>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
