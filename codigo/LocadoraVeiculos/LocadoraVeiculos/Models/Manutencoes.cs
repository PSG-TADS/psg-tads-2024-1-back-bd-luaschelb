using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculos.Models
{
    public class Manutencoes
    {
        [Key]
        public int Id { get; set; }
        public string? Descricao { get; set; }
        public DateTime Datalnicio { get; set; }
        public DateTime DataFim { get; set; }
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        public Veiculos Veiculo { get; set; }
        public int MecanicoId { get; set; }
        [ForeignKey("MecanicoId")]
        public Mecanicos Mecanico { get; set; }
    }
}
