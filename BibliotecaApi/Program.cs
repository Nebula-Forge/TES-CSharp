using BiblotecaApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

app.MapGet("/", () => "API Biblioteca");

// Funcionalidades

// LIVROS
// Cadastro de Livros: Permitir que o administrador da biblioteca cadastre novos livros, inserindo informações como título, autor, ISBN, etc.
// Pesquisa de Livro: Permitir que os usuários pesquisem livros por título, autor, gênero, etc.
// Reserva de Livros: Permitir que os usuários reservem livros que não estão disponíveis no momento, sendo notificados quando estiverem disponíveis.

// USUARIOS
// Cadastro de usuário: Permitir que novos usuários se cadastrem na biblioteca, fornecendo informações como nome, email, telefone, etc.
// Busca de Usuário: Permitir buscar usuário por meio de nome, email, ou id.
// Deletar Usuário: Permitir deletar usuário por meio de nome, email, ou id.
// Alterar dados Usuário: Permitir alterar usuário por meio de nome, email, ou id.

// EMPRESTIMOS
// Empréstimo de Livros: Usuários cadastrados podem solicitar empréstimos de livros disponíveis na biblioteca.
// Devolução de Livros: Usuários podem devolver os livros emprestados dentro do prazo estabelecido.
// Renovação de empréstimo: Permitir que os usuários solicitem a renovação do prazo de empréstimo, se o livro não estiver reservado por outro usuário.

app.MapPost("biblioteca/livro/cadastrar", ([FromBody] Livro livro, [FromServices] AppDataContext ctx) =>
{
    List<ValidationResult> erros = new List<ValidationResult>();
    if (!Validator.TryValidateObject(livro, new ValidationContext(livro), erros, true))
    {
        return Results.BadRequest(erros);
    }

    Livro? livroExistente = ctx.Livros.FirstOrDefault(x => x.ISBN == livro.ISBN);
    if (livroExistente != null)
    {
        return Results.BadRequest("Já existe um livro com o mesmo ISBN!");
    }

    ctx.Livros.Add(livro);
    ctx.SaveChanges();
    ret    /// Results.Created("", livro);
});

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