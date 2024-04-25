using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace BibliotecaApi.Migrations
{
    /// <inheritdoc />
    public partial class SeriesELivros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "assistido",
                table: "Filmes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    titulo = table.Column<string>(type: "longtext", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    autor = table.Column<string>(type: "longtext", nullable: false),
                    genero = table.Column<string>(type: "longtext", nullable: false),
                    finalizado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    titulo = table.Column<string>(type: "longtext", nullable: false),
                    ano = table.Column<int>(type: "int", nullable: false),
                    episodios = table.Column<int>(type: "int", nullable: false),
                    assistida = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropColumn(
                name: "assistido",
                table: "Filmes");
        }
    }
}
