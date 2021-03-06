﻿// <auto-generated />
using System;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Desafio.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Desafio.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<double>("Desconto")
                        .HasColumnType("float");

                    b.Property<double>("Quantidade")
                        .HasColumnType("float");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Codigo = "AB1",
                            Desconto = 0.0,
                            Quantidade = 1.0,
                            ValorTotal = 1.5,
                            ValorUnitario = 1.5
                        },
                        new
                        {
                            Id = 2,
                            Codigo = "AB2",
                            Desconto = 0.10000000000000001,
                            Quantidade = 2.0,
                            ValorTotal = 20.0,
                            ValorUnitario = 10.0
                        },
                        new
                        {
                            Id = 3,
                            Codigo = "XY5",
                            Desconto = 0.050000000000000003,
                            Quantidade = 5.0,
                            ValorTotal = 37.5,
                            ValorUnitario = 7.5
                        });
                });

            modelBuilder.Entity("Desafio.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<int?>("ItensId")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItensId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Desafio.Models.Pedido", b =>
                {
                    b.HasOne("Desafio.Models.Item", "Itens")
                        .WithMany("Pedidos")
                        .HasForeignKey("ItensId");

                    b.Navigation("Itens");
                });

            modelBuilder.Entity("Desafio.Models.Item", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
