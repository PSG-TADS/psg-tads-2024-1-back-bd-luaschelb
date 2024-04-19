using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Locadoras
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Endereco { get; set; }
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O número de telefone deve ser um celular válido.")]
        public string Telefone { get; set; }
        public ICollection<Funcionarios>? Funcionarios { get; set; }
    }
}
