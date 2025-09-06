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
            DateTime dataEmprestimo, 
            StatusEmprestimo statusEmprestimo) : base(id, dataCriacao)
        {
            LivroId = livroId;
            DataEmprestimo = dataEmprestimo;
            StatusEmprestimo = statusEmprestimo;
        }

        public Guid LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public StatusEmprestimo StatusEmprestimo { get; set; } = StatusEmprestimo.Ativo;
        public virtual Livro Livro { get; set; }
        public override bool Validar()
        {
            return IsValid;
        }
    }
}
