using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base (opcoes)
        {  
        }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Item>()
                .HasData(
                    new List<Item>()
                    {
                        new Item(1, "AB1", 1, 1.5, 0, 1.5),
                        new Item(2, "AB2", 2, 10, 0.10, 20),
                        new Item(3, "XY5", 5, 7.5, 0.05, 37.5)
                    }
                );
            builder.Entity<Pedido>()
                .HasData(
                    new List<Pedido>()
                    {
                        
                    }
                );
        }
    }
}