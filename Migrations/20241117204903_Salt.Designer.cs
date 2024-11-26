﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sorveteria.Contexts;

#nullable disable

namespace Sorveteria.Migrations
{
    [DbContext(typeof(ApplicationContext.ApplicationDbContext))]
    [Migration("20241117204903_Salt")]
    partial class Salt
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sorveteria.DTO.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantidadeBolas")
                        .HasColumnType("int");

                    b.Property<int>("Sabor1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Sabor2Id")
                        .HasColumnType("int");

                    b.Property<int?>("SaborId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("SaborId");

                    b.ToTable("Pedidos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NomeCliente = "Mousse de Maracuja",
                            QuantidadeBolas = 1,
                            Sabor1Id = 1,
                            Valor = 10.2m
                        });
                });

            modelBuilder.Entity("Sorveteria.DTO.Sabor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorBola")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Sabores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Mousse de Maracuja",
                            ValorBola = 10.2m
                        });
                });

            modelBuilder.Entity("Sorveteria.DTO.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "eduarbaldin@gmail.com",
                            Nome = "Admin Eduardo",
                            Senha = "123456"
                        });
                });

            modelBuilder.Entity("Sorveteria.DTO.Pedido", b =>
                {
                    b.HasOne("Sorveteria.DTO.Sabor", "Sabor")
                        .WithMany()
                        .HasForeignKey("SaborId");

                    b.Navigation("Sabor");
                });
#pragma warning restore 612, 618
        }
    }
}