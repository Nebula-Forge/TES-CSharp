using System.ComponentModel.DataAnnotations;

namespace BiblotecaApi.Models;

public class Usuario
{
    public Usuario(string nome, string email, string telefone, string endereco)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        CriadoEm = DateTime.Now;
    }

    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public string Nome { get; set; }

    [EmailAddress(ErrorMessage = "Email inválido!")]
    [Required(ErrorMessage = "Campo obrigatório!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public string Endereco { get; set; }
    public DateTime CriadoEm { get; set; }
}