using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using JsonOptions = Microsoft.AspNetCore.Http.Json.JsonOptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});


var app = builder.Build();

app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) => { return Results.Ok(dal.Listar()); }
);

app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
{
    var artista = dal.RecuperarPelo(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (artista is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(artista);
});

app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) =>
{
    dal.Adicionar(artista);
    return Results.Ok();
});

app.MapDelete("/Artista/{idArtista}", ([FromServices] DAL<Artista> dal, int idArtista) =>
{
    var artista = dal.RecuperarPelo(a => a.Id == idArtista);
    if (artista is null) return Results.NotFound();
    dal.Deletar(artista);
    return Results.NotFound();
});

app.MapPut("/Artista", ([FromServices] DAL<Artista> dal, [FromBody]Artista artista) =>
{
    var artistaParaAlaterar = dal.RecuperarPelo(a => a.Id == artista.Id);
    if (artistaParaAlaterar is null) return Results.NotFound();

    artistaParaAlaterar.Nome = artista.Nome;
    artistaParaAlaterar.Bio = artista.Bio;
    artistaParaAlaterar.FotoPerfil = artista.FotoPerfil;
    
    dal.Atualizar(artistaParaAlaterar);
    return Results.Ok();
});

app.Run();