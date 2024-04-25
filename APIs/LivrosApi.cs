using Microsoft.EntityFrameworkCore;

public static class LivrosApi {
    public static void MapLivrosApi(this WebApplication app) {
        var group = app.MapGroup("/livros");

        group.MapGet("/", async (BibliotecaContext db) =>

        await db.Livros.ToListAsync()
        );

        group.MapPost("/", async (Livro livro, BibliotecaContext db) => {
            db.Livros.Add(livro);
            await db.SaveChangesAsync();
            return Results.Created($"/Livros/{livro.Id}", livro);
        });
        
        group.MapPut("/", async (int id, Livro livroAlterado, BibliotecaContext db) => {
            var livro = await db.Livros.FindAsync(id);
            
            if (livro is null) {
                return Results.NotFound();
            }

            livro.titulo = livroAlterado.titulo;
            livro.ano = livroAlterado.ano;
            livro.autor = livroAlterado.autor;
            livro.genero = livroAlterado.genero;
            livro.finalizado = livroAlterado.finalizado;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });
        
        group.MapDelete("/{id}", async (int id, BibliotecaContext db) => {
            if (await db.Livros.FindAsync(id) is Livro livro) {
                db.Livros.Remove (livro);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });
        
    }
}