using Microsoft.EntityFrameworkCore;
using Sorveteria.Controllers;
using Sorveteria.DTO;

namespace Sorveteria.Contexts
{
    public class ApplicationContext
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
            public  DbSet<User> Users { get; set; }
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

                modelBuilder.Entity<Sabor>().HasData(
                    new Sabor
                    {
                        Id = 1,
                        Nome = "Mousse de Maracuja",
                        ValorBola = 10.2m
                    });

                modelBuilder.Entity<Pedido>()
                    .HasOne(p => p.Sabor1)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict); // Explicitly using NoAction

                modelBuilder.Entity<Pedido>()
                    .HasOne(p => p.Sabor2)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict); // Explicitly using NoAction

                modelBuilder.Entity<Pedido>().HasData(
                    new Pedido
                    {
                        Id = 1,
                        NomeCliente = "Eduardo",
                        QuantidadeBolas = 1,
                        Sabor1Id = 1,
                        Sabor2Id = null,
                        Valor = 10.2m,
                        Ativo = true
                    });
            }
        }
    }
}
