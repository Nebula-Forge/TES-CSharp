using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título do livro é obrigatório.")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O autor do livro é obrigatório.")]
        public string? Autor { get; set; }

        [Required(ErrorMessage = "O ISBN do livro é obrigatório.")]
        public string? ISBN { get; set; }

        public string? Editora { get; set; }

        public int AnoPublicacao { get; set; }

    }
}
