using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaApi.Migrations
{
    /// <inheritdoc />
    public partial class atz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "assistida",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "finalizado",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "finalizado",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "assistido",
                table: "Filmes");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Series",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Livros",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Jogos",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Filmes",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Livros");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Filmes");

            migrationBuilder.AddColumn<bool>(
                name: "assistida",
                table: "Series",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "finalizado",
                table: "Livros",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "finalizado",
                table: "Jogos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "assistido",
                table: "Filmes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
