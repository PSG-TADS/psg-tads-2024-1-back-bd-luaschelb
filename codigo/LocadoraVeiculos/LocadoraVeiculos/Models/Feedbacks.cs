using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculos.Models
{
    public class Feedbacks
    {
        [Key]
        public int Id { get; set; }
        public int ReservaId { get; set; }
        [ForeignKey("ReservaId")]
        public Reservas? Reserva { get; set; }
        public DateTime Data { get; set; }
        public string Canal { get; set; }
        public int Avaliacao { get; set; }
        public string? Comentarios { get; set; }
    }
}
