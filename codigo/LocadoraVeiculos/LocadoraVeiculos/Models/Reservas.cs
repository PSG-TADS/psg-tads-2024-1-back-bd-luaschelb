using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocadoraVeiculos.Models
{
    public class Reservas
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datalnicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal Valor { get; set; }
        public string? Status { get; set; }
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        public Veiculos? Veiculo { get; set; }
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Clientes? Cliente { get; set; }
        public int FuncionarioRetiradaId { get; set; } 
        [ForeignKey("FuncionarioRetiradaId")]
        public Funcionarios? FuncionarioRetirada { get; set; }
        public int FuncionarioEntradaId { get; set; }
        [ForeignKey("FuncionarioEntradaId")]
        public Funcionarios? FuncionarioEntrada { get; set; }
        public ICollection<Ocorrencias>? Ocorrencias { get; set; }
        public ICollection<Feedbacks>? Feedbacks { get; set; }
    }
}
