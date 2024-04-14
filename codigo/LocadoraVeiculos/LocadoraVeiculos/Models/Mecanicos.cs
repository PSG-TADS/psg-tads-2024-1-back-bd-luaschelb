using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Mecanicos
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public ICollection<Manutencoes> Manutencoes { get; set; }
    }
}
