using System.ComponentModel.DataAnnotations;

namespace LocadoraVeiculos.Models
{
    public class Veiculos
    {
        [Key]
        public int Id { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public decimal PrecoDia { get; set; }
        public ICollection<Reservas> Reservas { get; set; }
        public ICollection<Manutencoes> manutencoes { get; set; }
    }
}
