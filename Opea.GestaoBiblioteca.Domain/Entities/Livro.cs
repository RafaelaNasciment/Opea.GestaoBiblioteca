using Flunt.Notifications;
using Flunt.Validations;

namespace Opea.GestaoBiblioteca.Domain.Entities
{
    public class Livro : EntityBase
    {
        public Livro()
        {            
        }

        public Livro(
            Guid? id,
            DateTime? dataCriacao,
            string titulo, 
            string autor, 
            int anoPublicacao, 
            int quantidadeDisponivel) : base(id, dataCriacao)
        {
            Titulo = titulo;
            Autor = autor;
            AnoPublicacao = anoPublicacao;
            QuantidadeDisponivel = quantidadeDisponivel;
            Validar();
        }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }

        public void AdicionarEmprestimo(Emprestimo emprestimo)
        {
            Emprestimos ??= [];
            Emprestimos.Add(emprestimo);
            QuantidadeDisponivel--;
            Validar();
        }

        public override bool Validar()
        {
            var contrato = new Contract<Notification>()
                .IsNotNullOrWhiteSpace(Titulo, nameof(Titulo), "Titulo não informado!")
                .IsNotNullOrWhiteSpace(Autor, nameof(Autor), "Autor não informado!")
                .IsGreaterOrEqualsThan(AnoPublicacao, 1, nameof(AnoPublicacao), "Ano de publicação inválido!")
                .IsGreaterOrEqualsThan(QuantidadeDisponivel, 1, nameof(QuantidadeDisponivel), "Quantidade inválida!");

            AddNotifications(contrato);

            return IsValid;
        }
    }
}
