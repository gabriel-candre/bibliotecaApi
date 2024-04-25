using Microsoft.EntityFrameworkCore;

public static class SeriesApi {
    public static void MapSeriesApi(this WebApplication app) {
        var group = app.MapGroup("/series");

        group.MapGet("/", async (BibliotecaContext db) =>

        await db.Series.ToListAsync()
        );

        group.MapPost("/", async (Serie serie, BibliotecaContext db) => {
            db.Series.Add(serie);
            await db.SaveChangesAsync();
            return Results.Created($"/filmes/{serie.Id}", serie);
        });
        
        group.MapPut("/", async (int id, Serie serieAlterado, BibliotecaContext db) => {
            var serie = await db.Series.FindAsync(id);
            
            if (serie is null) {
                return Results.NotFound();
            }

            serie.titulo = serieAlterado.titulo;
            serie.ano = serieAlterado.ano;
            serie.episodios = serieAlterado.episodios;
            serie.assistida = serieAlterado.assistida;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });
        
        group.MapDelete("/{id}", async (int id, BibliotecaContext db) => {
            if (await db.Series.FindAsync(id) is Serie serie) {
                db.Series.Remove (serie);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            return Results.NotFound();
        });
        
    }
}