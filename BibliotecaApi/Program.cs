using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

app.MapGet("/", () => "API Biblioteca");

// LIVROS
// Cadastrar Livro
// app.MapPost();

// Pesquisar Livro
// app.MapGet();

// Listar Livros
// app.MapGet();

// Reservar Livro
// app.MapPut();

// USUÁRIOS
// Cadastrar Usuário
app.MapPost("biblioteca/usuario/cadastrar", ([FromBody] Usuario usuario, [FromServices] AppDataContext ctx) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();
    if (!Validator.TryValidateObject(
        usuario, new ValidationContext(usuario), erros, true
    ))
    {
        return Results.BadRequest(erros);
    }

    Usuario? usuarioEncontrado = ctx.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);
    if (usuarioEncontrado is null)
    {
        ctx.Usuarios.Add(usuario);
        ctx.SaveChanges();
        return Results.Created("", usuario);
    }
    return Results.BadRequest("Já existe um usuário com o mesmo email!");
});

// Listar Usuários
app.MapGet("biblioteca/usuario/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Usuarios.Any())
    {
        return Results.Ok(ctx.Usuarios.ToList());
    }
    return Results.NotFound("Não existem usuários!");
});

// Buscar Usuário
app.MapGet("biblioteca/usuario/buscar/{email}", ([FromRoute] string email, [FromServices] AppDataContext ctx) =>
{
    Usuario? usuario = ctx.Usuarios.Find(email);
    if (usuario is null)
    {
        return Results.NotFound("Usuário não encontrado!");
    }
    return Results.Ok(usuario);
});

// Deletar Usuário
app.MapDelete("biblioteca/usuario/remover/{email}", ([FromRoute] string email, [FromServices] AppDataContext ctx) =>
{
    Usuario? usuario = ctx.Usuarios.Find(email);
    if (usuario is null)
    {
        return Results.NotFound("Usuário não encontrado!");
    }
    ctx.Usuarios.Remove(usuario);
    ctx.SaveChanges();
    return Results.Ok("Usuário removido");
});

// Alterar dados Usuário
app.MapPut("biblioteca/usuario/alterar/{email}", ([FromRoute] string email, [FromBody] Usuario usuarioAlterado, [FromServices] AppDataContext ctx) =>
{
    Usuario? usuario = ctx.Usuarios.Find(email);
    if (usuario is null)
    {
        return Results.NotFound("Usuário não encontrado!");
    }
    usuario.Nome = usuarioAlterado.Nome;
    usuario.Email = usuarioAlterado.Email;
    usuario.Telefone = usuarioAlterado.Telefone;
    usuario.Endereco = usuarioAlterado.Endereco;
    ctx.Usuarios.Update(usuario);
    ctx.SaveChanges();
    return Results.Ok("Usuário alterado!");
});

// EMPRÉSTIMOS
// Emprestar Livros
// app.MapPut();

// Devolver Livros
// app.MapPut();

// Renovar Empréstimo
// app.MapPut();