using Microsoft.EntityFrameworkCore;

public class BibliotecaContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=biblioteca;user=root;password=positivo");
    }
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Jogo> Jogos { get; set; }
}