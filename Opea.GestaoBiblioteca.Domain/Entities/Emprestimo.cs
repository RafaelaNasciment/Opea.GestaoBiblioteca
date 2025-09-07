using Opea.GestaoBiblioteca.Domain.Enums;

namespace Opea.GestaoBiblioteca.Domain.Entities
{
    public class Emprestimo : EntityBase
    {
        public Emprestimo()
        {
        }

        public Emprestimo(
            Guid? id,
            DateTime? dataCriacao,
            Guid livroId) : base(id, dataCriacao)
        {
            LivroId = livroId;
            DataEmprestimo = DataCriacao;
        }

        public Guid LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public StatusEmprestimo StatusEmprestimo { get; set; } = StatusEmprestimo.Ativo;
        public virtual Livro Livro { get; set; }

        public void DevolverEmprestimo()
        {
            if (StatusEmprestimo == StatusEmprestimo.Devolvido)            
                AddNotification(nameof(StatusEmprestimo), "Empréstimo já foi devolvido!.");
            else
                StatusEmprestimo = StatusEmprestimo.Devolvido;

            DataDevolucao = DateTime.UtcNow;
            Livro.QuantidadeDisponivel++;
            Validar();
        }

        public override bool Validar()
        {
            return IsValid;
        }
    }
}
