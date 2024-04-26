using Microsoft.EntityFrameworkCore;

public static class JogosApi {
    public static void MapJogosApi(this WebApplication app) {
        var group = app.MapGroup("/jogos");

        group.MapGet("/", async (BibliotecaContext db) =>

        await db.Jogos.ToListAsync()
        );

        group.MapPost("/", async (Jogo jogo, BibliotecaContext db) => {
            db.Jogos.Add(jogo);
            await db.SaveChangesAsync();
            return Results.Created($"/jogos/{jogo.Id}", jogo);
        });
        
        group.MapPut("/", async (int id, Jogo jogoAlterado, BibliotecaContext db) => {
            var jogo = await db.Jogos.FindAsync(id);
            
            if (jogo is null) {
                return Results.NotFound();
            }

            jogo.titulo = jogoAlterado.titulo;
            jogo.ano = jogoAlterado.ano;
            jogo.publicadora = jogoAlterado.publicadora;
            jogo.finalizado = jogoAlterado.finalizado;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });
        
        group.MapDelete("/{id}", async (int id, BibliotecaContext db) => {
            if (await db.Jogos.FindAsync(id) is Jogo  jogo) {
                db.Jogos.Remove (jogo);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });
        
    }
}