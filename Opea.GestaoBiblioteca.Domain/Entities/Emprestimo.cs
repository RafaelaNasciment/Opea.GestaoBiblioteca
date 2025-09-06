using Opea.GestaoBiblioteca.Domain.Enums;

namespace Opea.GestaoBiblioteca.Domain.Entities
{
    public class Emprestimo : EntityBase
    {
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
