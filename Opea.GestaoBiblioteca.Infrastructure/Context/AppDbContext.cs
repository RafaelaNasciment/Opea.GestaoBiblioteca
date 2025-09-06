using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Opea.GestaoBiblioteca.Domain.Entities;
using Opea.GestaoBiblioteca.Domain.Enums;
using Opea.GestaoBiblioteca.Infrastructure.ValueObjects;

namespace Opea.GestaoBiblioteca.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public AppDbContext()
        {
        }

        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Livro> Livro { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Livros
            modelBuilder.Entity<Livro>().HasData(
                new Livro(id: MigrationBase.BaseId001, dataCriacao: MigrationBase.DataBase, titulo: "O Senhor dos Anéis", autor: "J.R.R. Tolkien", anoPublicacao: 1954, quantidadeDisponivel: 5),
                new Livro(id: MigrationBase.BaseId002, dataCriacao: MigrationBase.DataBase, titulo: "1984", autor: "George Orwell", anoPublicacao: 1949, quantidadeDisponivel: 3),
                new Livro(id: MigrationBase.BaseId003, dataCriacao: MigrationBase.DataBase, titulo: "Dom Casmurro", autor: "Machado de Assis", anoPublicacao: 1899, quantidadeDisponivel: 2)
            );

            modelBuilder.Entity<Emprestimo>().HasData(
                new Emprestimo { Id = MigrationBase.BaseId004, LivroId = MigrationBase.BaseId001, DataCriacao = MigrationBase.DataBase, DataEmprestimo = MigrationBase.DataBase, StatusEmprestimo = StatusEmprestimo.Ativo },
                new Emprestimo { Id = MigrationBase.BaseId005, LivroId = MigrationBase.BaseId002, DataCriacao = MigrationBase.DataBase, DataEmprestimo = MigrationBase.DataBase, DataDevolucao = new DateTime(2025, 09, 04), StatusEmprestimo = StatusEmprestimo.Devolvido },
                new Emprestimo { Id = MigrationBase.BaseId006, LivroId = MigrationBase.BaseId003, DataCriacao = MigrationBase.DataBase, DataEmprestimo = MigrationBase.DataBase, StatusEmprestimo = StatusEmprestimo.Ativo }
            );
        }

    }
}
