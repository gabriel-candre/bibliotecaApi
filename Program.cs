var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BibliotecaContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Biblioteca API");

app.MapFilmesApi();
app.MapSeriesApi();
app.MapLivrosApi();
app.MapJogosApi();

app.Run();
