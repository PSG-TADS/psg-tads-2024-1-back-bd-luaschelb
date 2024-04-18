using Microsoft.EntityFrameworkCore;
using LocadoraVeiculos.Models;

namespace LocadoraVeiculos.Models
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options) { }
        public DbSet<Veiculos> Veiculos { get; set; } = null;
        public DbSet<Clientes> Clientes { get; set; } = null;
        public DbSet<Funcionarios> Funcionarios { get; set; } = null;
        public DbSet<Reservas> Reservas{ get; set; } = null;
        public DbSet<Manutencoes> Manutencoes { get; set; } = null;
        public DbSet<Mecanicos> Mecanicos { get; set; } = null;
        public DbSet<Ocorrencias> Ocorrencias { get; set; } = null;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=LocadoraDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionarios>()
                .Property(f => f.Salario)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Reservas>()
                .Property(r => r.Valor)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Veiculos>()
                .Property(v => v.PrecoDia)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Funcionarios>()
                .HasMany(f => f.ReservasRetirada)
                .WithOne(r => r.FuncionarioRetirada)
                .HasForeignKey(r => r.FuncionarioRetiradaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Funcionarios>()
                .HasMany(f => f.ReservasEntrada)
                .WithOne(r => r.FuncionarioEntrada)
                .HasForeignKey(r => r.FuncionarioEntradaId);
        }
        public DbSet<LocadoraVeiculos.Models.Locadoras> Locadoras { get; set; } = default!;
        public DbSet<LocadoraVeiculos.Models.Feedbacks> Feedbacks { get; set; } = default!;
    }
}
