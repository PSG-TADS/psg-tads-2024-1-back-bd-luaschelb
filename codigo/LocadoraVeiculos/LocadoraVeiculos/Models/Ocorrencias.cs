using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculos.Models
{
    public class Ocorrencias
    {
        [Key]
        public int Id { get; set; }

        public int ReservaId { get; set; }
        [ForeignKey("ReservaId")]
        public Reservas Reserva { get; set; }
        public DateTime DataAcidente { get; set; }
        public string? Local { get; set; }
        public string? Descricao { get; set; }
        public string? Danos { get; set; }
        public string? LesoesPassageiros { get; set; }
        public string? RelatorioPolicial { get; set; }

        [Column(TypeName = "text")]
        public string? Fotos { get; set; }

        public string? AcoesTomadas { get; set; }
    }
}
