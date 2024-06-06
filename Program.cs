using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
//Configuração de CORs
builder.Services.AddCors();
//Configuração Swagger no builder
//http://localhost:porta/swagger/index.html
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configura a serialização do JSON para evitar referência circular
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
  options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);
//Configuração banco MySQL
builder.Services.AddDbContext<BibliotecaContext>();
var app = builder.Build();
//Configuração CORs
app.UseCors(builder => builder
  .AllowAnyOrigin()
  .AllowAnyHeader()
  .AllowAnyMethod()
);
//Configuração Swagger no app
app.UseSwagger();
app.UseSwaggerUI();
//APIs
app.MapGet("/", () => "Biblioteca API");
app.MapFilmesApi();
app.MapJogosApi();
app.MapLivrosApi();
app.MapSeriesApi();
app.Run();