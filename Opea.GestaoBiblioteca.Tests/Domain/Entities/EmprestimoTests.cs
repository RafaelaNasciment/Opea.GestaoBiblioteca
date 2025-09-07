using Opea.GestaoBiblioteca.Domain.Entities;
using Xunit;

namespace Opea.GestaoBiblioteca.Tests.Domain.Entities
{
    public class EmprestimoTests
    {
        [Theory(DisplayName = "Aumentar QuantidadeDisponivel ao devolver um empréstimo")]
        [Trait("Entity", "Emprestimo")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void AumentarQuantidadeDisponivelAoDevolverUmEmprestimo(int quantidadeDisponivel)
        {
            // arrange
            var emprestimo = new Emprestimo(Guid.NewGuid(), null, Guid.NewGuid())
            {
                Livro = new Livro(Guid.NewGuid(), null, "Titulo informado", "Autor Válido", 2000, quantidadeDisponivel)
            };

            var quantidadeAtualizada = quantidadeDisponivel + 1;
            // act
            emprestimo.DevolverEmprestimo();

            // assert
            Assert.Equal(quantidadeAtualizada, emprestimo.Livro.QuantidadeDisponivel);
        }

        [Fact(DisplayName = "Nao Deve Devolver Um Emprestimo Que Ja Foi Devolvido")]
        [Trait("Entity", "Emprestimo")]
        public void NaoDeveDevolverUmEmprestimoQueJaFoiDevolvido()
        {
            // arrange
            var emprestimo = new Emprestimo(Guid.NewGuid(), null, Guid.NewGuid())
            {
                StatusEmprestimo = GestaoBiblioteca.Domain.Enums.StatusEmprestimo.Devolvido,
                Livro = new Livro(Guid.NewGuid(), null, "Titulo informado", "Autor Válido", 2000, 1)
            };                     
            // act
            emprestimo.DevolverEmprestimo();

            // assert
            Assert.False(emprestimo.IsValid);
            Assert.Contains("Empréstimo já foi devolvido!.", emprestimo.Notifications.Select(x => x.Message));
        }

        [Fact(DisplayName = "Emprestimo criado com sucesso")]
        [Trait("Entity", "Emprestimo")]
        public void EmprestimoCriadoComSucesso()
        {
            // arrange
            var emprestimo = new Emprestimo(Guid.NewGuid(), null, Guid.NewGuid())
            {                
            };                     
            // act           

            // assert
            Assert.True(emprestimo.IsValid);
        }
    }
}
