using Microsoft.EntityFrameworkCore;

public static class FilmesApi {
    public static void MapFilmesApi(this WebApplication app) {
        var group = app.MapGroup("/filmes");

        group.MapGet("/", async (BibliotecaContext db) =>

        await db.Filmes.ToListAsync()
        );

        group.MapPost("/", async (Filme filme, BibliotecaContext db) => {
            db.Filmes.Add(filme);
            await db.SaveChangesAsync();
            return Results.Created($"/filmes/{filme.Id}", filme);
        });
        
        group.MapPut("/{id}", async (int id, Filme filmeAlterado, BibliotecaContext db) => {
            var filme = await db.Filmes.FindAsync(id);
            
            if (filme is null) {
                return Results.NotFound();
            }

            filme.titulo = filmeAlterado.titulo;
            filme.ano = filmeAlterado.ano;
            filme.duracao = filmeAlterado.duracao;
            filme.status = filmeAlterado.status;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });
        
        group.MapDelete("/{id}", async (int id, BibliotecaContext db) => {
            if (await db.Filmes.FindAsync(id) is Filme filme) {
                db.Filmes.Remove (filme);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });
        
    }
}