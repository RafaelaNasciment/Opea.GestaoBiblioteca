using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Opea.GestaoBiblioteca.Domain.Entities;

namespace Opea.GestaoBiblioteca.Infrastructure.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder
                .ToTable("Livro")
                .HasKey(p => p.Id);

            builder
                .Property(p => p.DataCriacao)
                .HasColumnType("datetime2")
                .IsRequired();

            builder
                .Property(p => p.Titulo)
                .HasColumnType("VARCHAR(254)")
                .IsRequired();

            builder
                .Property(p => p.Autor)
                .HasColumnType("VARCHAR(254)")
                .IsRequired();

            builder
                .Property(p => p.AnoPublicacao)
                .HasColumnType("INT")
                .IsRequired();

            builder
                .Property(p => p.QuantidadeDisponivel)
                .HasColumnType("INT")
                .IsRequired();
        }
    }
}
