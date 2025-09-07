using Flunt.Notifications;
using Flunt.Validations;
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
            Guid livroId,
            DateTime dataEmprestimo) : base(id, dataCriacao)
        {
            LivroId = livroId;
            DataEmprestimo = dataEmprestimo;
        }

        public Guid LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public StatusEmprestimo StatusEmprestimo { get; set; } = StatusEmprestimo.Ativo;
        public virtual Livro Livro { get; set; }

        public void DevolverEmprestimo()
        {
            StatusEmprestimo = StatusEmprestimo.Devolvido;
            DataDevolucao = DateTime.UtcNow;
            Livro.QuantidadeDisponivel++;
            Validar();
        }

        public void SolicitarEmprestimo()
        {
            StatusEmprestimo = StatusEmprestimo.Ativo;
            Validar();
        }

        public override bool Validar()
        {
            return IsValid;
        }
    }
}
