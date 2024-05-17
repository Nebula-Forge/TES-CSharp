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

  public string? Id { get; set; }
  public DateTime DataEmprestimo { get; set; }
  public DateTime DataDevolucaoPrevista { get; set; }
  public DateTime? DataDevolucaoReal { get; set; }
  public string? Status { get; set; }

  [Required(ErrorMessage = "O usuário é obrigatório.")]
  public Usuario? Usuario { get; set; }
  public string? UsuarioId { get; set; }

  [Required(ErrorMessage = "Para o emprestimo é obrigatório no mínimo 01 livro.")]
  public virtual List<Livro>? Livros { get; set; }
}