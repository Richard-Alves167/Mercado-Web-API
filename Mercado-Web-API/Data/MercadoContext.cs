using System.Data.Common;
using System.Reflection.Metadata;
using Mercado_Web_API.Models;
using Mercado_Web_API.Models.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Mercado_Web_API.Data {
    public class MercadoContext : DbContext {
        public MercadoContext(DbContextOptions<MercadoContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<FornecedorProduto> FornecedoresProdutos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Compra>()
            .HasOne(c => c.Cliente)
            .WithMany(c => c.Compras)
            .HasForeignKey(c => c.IdCliente)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Item>()
            .HasOne(i => i.Compra)
            .WithMany(i => i.Itens)
            .HasForeignKey(i => i.IdCompra)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Item>()
            .HasOne(i => i.Produto)
            .WithMany(i => i.Itens)
            .HasForeignKey(i => i.IdProduto)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Fornecedor>()
            .HasMany(f => f.Produtos)
            .WithMany(f => f.Fornecedores)
            .UsingEntity<FornecedorProduto>();

            modelBuilder.Entity<FornecedorProduto>()
            .HasKey(fp => new {fp.IdFornecedor, fp.IdProduto});
        }
    }
}
