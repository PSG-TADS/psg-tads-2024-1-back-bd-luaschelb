using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculos.Models
{
    public class Funcionarios
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataContracao { get; set; }
        public int LocadoraId { get; set; }
        [ForeignKey("LocadoraId")]
        public Locadoras? Locadora{ get; set; }
        public ICollection<Reservas>? ReservasRetirada { get; set; }
        public ICollection<Reservas>? ReservasEntrada { get; set; }
    }
}
