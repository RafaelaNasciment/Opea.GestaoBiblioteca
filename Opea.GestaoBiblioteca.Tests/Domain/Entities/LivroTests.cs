using Opea.GestaoBiblioteca.Domain.Entities;
using Xunit;

namespace Opea.GestaoBiblioteca.Tests.Domain.Entities
{
    public class LivroTests
    {
        [Fact(DisplayName = "Não deve criar livro sem título")]
        [Trait("Entity", "Livro")]
        public void NaoDeveCriarLivroSemTitulo()
        {
            // arrange
            var livro = new Livro(Guid.NewGuid(), null, titulo: "", "Autor Válido", 2000, 1);

            // act
            var valido = livro.Validar();

            // assert
            Assert.False(valido);
            Assert.NotEmpty(livro.Notifications);
            Assert.Contains("Titulo não informado!", livro.Notifications.Select(x => x.Message));
        }

        [Fact(DisplayName = "Não deve criar livro sem autor")]
        [Trait("Entity", "Livro")]
        public void NaoDeveCriarLivroSemAutor()
        {
            // arrange
            var livro = new Livro(Guid.NewGuid(), null, "Titulo informado", "", 2000, 1);

            // act
            var valido = livro.Validar();

            // assert
            Assert.False(valido);
            Assert.NotEmpty(livro.Notifications);
            Assert.Contains("Autor não informado!", livro.Notifications.Select(x => x.Message));
        }

        [Fact(DisplayName = "Não deve criar livro sem quantidadeDisponivel")]
        [Trait("Entity", "Emprestimo")]
        public void NaoDeveCriarLivroSemQuantidadeDisponivel()
        {
            // arrange
            var livro = new Livro(Guid.NewGuid(), null, "Titulo informado", "Autor informado", 2000, 0);

            // act
            var valido = livro.Validar();

            // assert
            Assert.False(valido);
            Assert.NotEmpty(livro.Notifications);
            Assert.Contains("Quantidade inválida!", livro.Notifications.Select(x => x.Message));
        }

        [Theory(DisplayName = "Reduzir QuantidadeDisponivel ao realizar um empréstimo")]
        [Trait("Entity", "Livro")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ReduzirQuantidadeDisponivelAoRealizarUmEmprestimo(int quantidadeDisponivel)
        {
            // arrange
            var livro = new Livro(Guid.NewGuid(), null, "Titulo informado", "Autor Válido", 2000, quantidadeDisponivel);
            var quantidadeAtualizada = quantidadeDisponivel - 1;
            // act
            livro.AdicionarEmprestimo(new Emprestimo(Guid.NewGuid(), null, livro.Id));

            // assert
            Assert.Equal(quantidadeAtualizada, livro.QuantidadeDisponivel);
        }

        [Fact(DisplayName = "Criar Livro Retorna Sucesso")]
        [Trait("Entity", "Livro")]
        public void CriarLivroRetornaSucesso()
        {
            // arrange
            var livro = new Livro(Guid.NewGuid(), null, "Titulo informado", "Autor informado", 2000, 1);

            // act
            var valido = livro.Validar();

            // assert
            Assert.False(!valido);
        }
    }
}