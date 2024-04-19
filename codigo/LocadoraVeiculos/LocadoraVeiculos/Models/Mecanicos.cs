using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Mecanicos
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O número de telefone deve ser um celular válido.")]
        public string Telefone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<Manutencoes>? Manutencoes { get; set; }
    }
}
