using BiblotecaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Biblioteca API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Biblioteca API v1");
        c.RoutePrefix = string.Empty;
    });
}


//Cadastrar Livros
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
    return Results.Created("", livro);
});

//Listar Livros
app.MapGet("biblioteca/livro/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Livros.Any())
    {
        return Results.Ok(ctx.Livros.ToList());
    }
    return Results.NotFound("Não existem livros cadastrados.");
});

// Buscar Livro
app.MapGet("biblioteca/livro/buscar/{titulo}", ([FromRoute] string titulo, [FromServices] AppDataContext ctx) =>
{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    Livro? livro = ctx.Livros.FirstOrDefault(l => l.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    if (livro is null)
    {
        return Results.NotFound("Livro não encontrado!");
    }
    return Results.Ok(livro);
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
    Usuario? usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);
    if (usuario is null)
    {
        return Results.NotFound("Usuário não encontrado!");
    }
    return Results.Ok(usuario);
});

// Deletar Usuário
app.MapDelete("biblioteca/usuario/remover/{email}", ([FromRoute] string email, [FromServices] AppDataContext ctx) =>
{
    Usuario? usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);
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
    Usuario? usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);
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

// Emprestar Livro
app.MapPost("biblioteca/emprestimo/emprestar/{email}", ([FromBody] Emprestimo emprestimoBody, [FromRoute] string email, [FromServices] AppDataContext ctx) =>
{
    Usuario? usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

    if (usuario is null)
    {
        return Results.NotFound("Usuário não encontrado!");
    }

    List<Livro> livros = new List<Livro>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    foreach (var idLivro in emprestimoBody.LivroIds)
    {
        Livro? livroEncontrado = ctx.Livros.Find(idLivro);

        if (livroEncontrado is null)
        {
            return Results.NotFound("Livro não encontrado!");
        }
        if (livroEncontrado.EmprestimoId is not null)
        {
            return Results.BadRequest("Livro já emprestado!");
        }

        livros.Add(livroEncontrado);
    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    Emprestimo emprestimo = new Emprestimo(usuario.Id, emprestimoBody.LivroIds);
    emprestimo.Livros = livros;

    foreach (var idLivro in emprestimoBody.LivroIds)
    {
        Livro? livroEncontrado = ctx.Livros.Find(idLivro);

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        livroEncontrado.EmprestimoId = emprestimoBody.Id;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        ctx.Livros.Update(livroEncontrado);

    }

    ctx.Emprestimos.Add(emprestimo);
    ctx.SaveChanges();
    return Results.Created("", emprestimo);
});

// Devolver Livro
app.MapPut("biblioteca/emprestimo/devolver/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) =>
{
    Emprestimo? emprestimo = ctx.Emprestimos.Find(int.Parse(id));

    if (emprestimo is null)
    {
        return Results.NotFound("Empréstimo não encontrado!");
    }

    if (emprestimo.DataDevolucaoReal is not null)
    {
        return Results.BadRequest("Empréstimo já devolvido!");
    }

    emprestimo.DataDevolucaoReal = DateTime.Now;
    emprestimo.Status = "Devolvido";

    if (emprestimo.Livros is not null)
    {
        foreach (var livro in emprestimo.Livros)
        {
            livro.EmprestimoId = null;
        }

    }

    ctx.Emprestimos.Update(emprestimo);
    ctx.SaveChanges();
    return Results.Ok("Livro devolvido!");
});

// Renovar Empréstimo
app.MapPut("biblioteca/emprestimo/renovar/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) =>
{
    Emprestimo? emprestimo = ctx.Emprestimos.Find(int.Parse(id));

    if (emprestimo is null)
    {
        return Results.NotFound("Empréstimo não encontrado!");
    }

    if (emprestimo.Status == "Devolvido")
    {
        return Results.BadRequest("Empréstimo já devolvido!");
    }

    if (emprestimo.Status == "Renovado")
    {
        return Results.BadRequest("Empréstimo já renovado!");
    }

    emprestimo.DataDevolucaoPrevista = emprestimo.DataDevolucaoPrevista.AddDays(7);
    emprestimo.Status = "Renovado";

    ctx.Emprestimos.Update(emprestimo);
    ctx.SaveChanges();
    return Results.Ok("Empréstimo renovado!");
});

//Listar Emprestimos
app.MapGet("biblioteca/emprestimo/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Emprestimos.Any())
    {
        List<Emprestimo> emprestimos = ctx.Emprestimos.ToList();

        foreach (var emprestimo in emprestimos)
        {
            int usuarioId = emprestimo.UsuarioId;
            Usuario? usuario = ctx.Usuarios.Find(usuarioId);
            emprestimo.Usuario = usuario;

            List<Livro> livros = new List<Livro>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            foreach (var idLivro in emprestimo.LivroIds)
            {
                Livro? livro = ctx.Livros.Find(idLivro);
                if (livro is not null)
                {
                    livros.Add(livro);
                }
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            emprestimo.Livros = livros;
        }
        return Results.Ok(ctx.Emprestimos.ToList());
    }
    return Results.NotFound("Não existem empréstimos!");
});

//Buscar Emprestimo por Id
app.MapGet("biblioteca/emprestimo/buscar/{id}", ([FromRoute] string id, [FromServices] AppDataContext ctx) =>
{
    Emprestimo? emprestimo = ctx.Emprestimos.Find(int.Parse(id));

    if (emprestimo is null)
    {
        return Results.NotFound("Empréstimo não encontrado!");
    }
    int usuarioId = emprestimo.UsuarioId;
    Usuario? usuario = ctx.Usuarios.Find(usuarioId);
    emprestimo.Usuario = usuario;

    List<Livro> livros = new List<Livro>();
#pragma warning disable CS8602 // Dereference of a possibly null reference.
    foreach (var idLivro in emprestimo.LivroIds)
    {
        Livro? livro = ctx.Livros.Find(idLivro);
        if (livro is not null)
        {
            livros.Add(livro);
        }
    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    emprestimo.Livros = livros;
    return Results.Ok(emprestimo);
});

app.Run();