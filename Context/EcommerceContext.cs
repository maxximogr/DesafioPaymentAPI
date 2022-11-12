using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options) { 

        }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Venda>().Property(v => v.Produtos)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)default),
                v => JsonSerializer.Deserialize<List<Produto>>(v, (JsonSerializerOptions)default));


            base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore <List<string>>();
        modelBuilder.Ignore <ICollection<String>>();
        }

    }
}