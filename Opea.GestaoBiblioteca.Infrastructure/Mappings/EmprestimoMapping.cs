using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opea.GestaoBiblioteca.Domain.Entities;

namespace Opea.GestaoBiblioteca.Infrastructure.Mappings
{
    public class EmprestimoMapping : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder
                .ToTable("Emprestimo")
                .HasKey(p => p.Id);

            builder
                .Property(p => p.DataCriacao)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder
                .Property(p => p.DataEmprestimo)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder
                .Property(p => p.DataDevolucao)
                .HasColumnType("DATETIME")
                .IsRequired(false);

            builder
                .Property(p => p.StatusEmprestimo)
                .HasColumnType("INT")
                .IsRequired();

            builder.HasOne(p => p.Livro).WithMany(p => p.Emprestimos).HasForeignKey(p => p.LivroId);
        }
    }
}
