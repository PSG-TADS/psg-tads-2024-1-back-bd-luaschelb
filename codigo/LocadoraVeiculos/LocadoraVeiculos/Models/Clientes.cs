using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public ICollection<Reservas>? Reservas { get; set; }
    }
}
