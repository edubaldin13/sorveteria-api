using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Sorveteria.DTO;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Security.Principal;

namespace Sorveteria.Contexts
{
    public class ApplicationContext
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
            public DbSet<User> Users { get; set; }
            public DbSet<Pedido> Pedidos { get; set; }
            public DbSet<Sabor> Sabores { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>()
                .HasIndex(e => e.Email).IsUnique();
                modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Email = "eduarbaldin@gmail.com",
                    Senha = "123456",
                    Nome = "Admin Eduardo"
                });
                //criar user
                modelBuilder.Entity<Sabor>().HasData(
                new Sabor()
                {
                    Id = 1,
                    Nome = "Mousse de Maracuja",
                    ValorBola = new decimal(10.2)
                });
                modelBuilder.Entity<Pedido>().HasData(
                new Pedido()
                {
                    Id = 1,
                    NomeCliente = "Mousse de Maracuja",
                    QuantidadeBolas = 1,
                    Sabor1Id = 1,
                    Sabor2Id = null,
                    Valor = new decimal(10.2)
                });
            }
        }
    }
}