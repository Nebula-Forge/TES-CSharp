using System.ComponentModel.DataAnnotations;
namespace BiblotecaApi.Models;
public class Emprestimo
{
  public Emprestimo() { }
  public Emprestimo(int usuarioId, List<int> livrosIds)
  {
    UsuarioId = usuarioId;
    LivroIds = livrosIds;
    DataEmprestimo = DateTime.Now;
    DataDevolucaoPrevista = DateTime.Now.AddDays(7);
    Status = "Em andamento";
  }

  [Key]
  public int? Id { get; set; }
  public DateTime DataEmprestimo { get; set; }
  public DateTime DataDevolucaoPrevista { get; set; }
  public DateTime? DataDevolucaoReal { get; set; }
  public string? Status { get; set; }

  [Required(ErrorMessage = "O usuário é obrigatório.")]
  public Usuario? Usuario { get; set; }
  public int UsuarioId { get; set; }

  [Required(ErrorMessage = "Para o emprestimo é obrigatório no mínimo 01 livro.")]
  public virtual List<Livro>? Livros { get; set; }
  public List<int>? LivroIds { get; set; }
}