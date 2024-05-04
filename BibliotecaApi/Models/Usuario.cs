using System.ComponentModel.DataAnnotations;

namespace API.Models;

public class Usuario
{
    public Usuario(string nome, string email, string telefone, string endereco)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        CriadoEm = DateTime.Now;
    }

    public string Id { get; set; }
    public DateTime CriadoEm { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public string Nome { get; set; }

    [EmailAddress(ErrorMessage = "Email inválido!")]
    [Required(ErrorMessage = "Campo obrigatório!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "Campo obrigatório!")]
    public string Endereco { get; set; }
}