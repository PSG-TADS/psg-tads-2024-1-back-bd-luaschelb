using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Locadoras
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Endereco{ get; set; }
        public string Telefone { get; set; }
        public ICollection<Funcionarios>? Funcionarios { get; set; }
    }
}
