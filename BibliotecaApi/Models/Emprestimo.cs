using System.ComponentModel.DataAnnotations;
namespace BiblotecaApi.Models;
public class Emprestimo
{
  public Emprestimo() { }
  public Emprestimo(Usuario usuario, List<Livro> livros)
  {
    Id = Guid.NewGuid().ToString();
    Usuario = usuario;
    Livros = livros;
    DataEmprestimo = DateTime.Now;
    DataDevolucaoPrevista = DateTime.Now.AddDays(7);
    Status = "Em andamento";
  }

  public string? Id { get; private set; }
  public DateTime DataEmprestimo { get; private set; }
  public DateTime DataDevolucaoPrevista { get; private set; }
  public DateTime? DataDevolucaoReal { get; private set; }
  public string Status { get; private set; }

  public Usuario? Usuario { get; private set; }
  public string? UsuarioId { get; private set; }

  public virtual List<Livro>? Livros { get; private set; }
}