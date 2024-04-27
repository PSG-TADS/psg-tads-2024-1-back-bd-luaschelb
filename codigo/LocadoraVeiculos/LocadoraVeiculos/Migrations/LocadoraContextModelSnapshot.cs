﻿// <auto-generated />
using System;
using LocadoraVeiculos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LocadoraVeiculos.Migrations
{
    [DbContext(typeof(LocadoraContext))]
    partial class LocadoraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LocadoraVeiculos.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Feedbacks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Avaliacao")
                        .HasColumnType("int");

                    b.Property<string>("Canal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentarios")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Funcionarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataContracao")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocadoraId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("LocadoraId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Locadoras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locadoras");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Manutencoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Datalnicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MecanicoId")
                        .HasColumnType("int");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MecanicoId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Manutencoes");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Mecanicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Mecanicos");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Ocorrencias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AcoesTomadas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Danos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAcidente")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fotos")
                        .HasColumnType("text");

                    b.Property<string>("LesoesPassageiros")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelatorioPolicial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReservaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.ToTable("Ocorrencias");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Reservas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Datalnicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FuncionarioEntradaId")
                        .HasColumnType("int");

                    b.Property<int?>("FuncionarioRetiradaId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FuncionarioEntradaId");

                    b.HasIndex("FuncionarioRetiradaId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Veiculos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ano")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrecoDia")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Feedbacks", b =>
                {
                    b.HasOne("LocadoraVeiculos.Models.Reservas", "Reserva")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Funcionarios", b =>
                {
                    b.HasOne("LocadoraVeiculos.Models.Locadoras", "Locadora")
                        .WithMany("Funcionarios")
                        .HasForeignKey("LocadoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locadora");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Manutencoes", b =>
                {
                    b.HasOne("LocadoraVeiculos.Models.Mecanicos", "Mecanico")
                        .WithMany("Manutencoes")
                        .HasForeignKey("MecanicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Models.Veiculos", "Veiculo")
                        .WithMany("manutencoes")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mecanico");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Ocorrencias", b =>
                {
                    b.HasOne("LocadoraVeiculos.Models.Reservas", "Reserva")
                        .WithMany("Ocorrencias")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Reservas", b =>
                {
                    b.HasOne("LocadoraVeiculos.Models.Clientes", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LocadoraVeiculos.Models.Funcionarios", "FuncionarioEntrada")
                        .WithMany("ReservasEntrada")
                        .HasForeignKey("FuncionarioEntradaId");

                    b.HasOne("LocadoraVeiculos.Models.Funcionarios", "FuncionarioRetirada")
                        .WithMany("ReservasRetirada")
                        .HasForeignKey("FuncionarioRetiradaId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("LocadoraVeiculos.Models.Veiculos", "Veiculo")
                        .WithMany("Reservas")
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("FuncionarioEntrada");

                    b.Navigation("FuncionarioRetirada");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Clientes", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Funcionarios", b =>
                {
                    b.Navigation("ReservasEntrada");

                    b.Navigation("ReservasRetirada");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Locadoras", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Mecanicos", b =>
                {
                    b.Navigation("Manutencoes");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Reservas", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Ocorrencias");
                });

            modelBuilder.Entity("LocadoraVeiculos.Models.Veiculos", b =>
                {
                    b.Navigation("Reservas");

                    b.Navigation("manutencoes");
                });
#pragma warning restore 612, 618
        }
    }
}
