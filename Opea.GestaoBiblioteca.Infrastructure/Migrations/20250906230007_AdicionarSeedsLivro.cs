using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Opea.GestaoBiblioteca.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarSeedsLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Livro",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");

            migrationBuilder.InsertData(
                table: "Livro",
                columns: new[] { "Id", "AnoPublicacao", "Autor", "DataCriacao", "QuantidadeDisponivel", "Titulo" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), 1954, "J.R.R. Tolkien", new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), 5, "O Senhor dos Anéis" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 1949, "George Orwell", new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), 3, "1984" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 1899, "Machado de Assis", new DateTime(2025, 9, 6, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Dom Casmurro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Livro",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Livro",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Livro",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Livro",
                type: "DATETIME",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
