using System.Data.Common;
using Mercado_Web_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Mercado_Web_API.Data {
    public class MercadoContext : DbContext {
        public MercadoContext(DbContextOptions<MercadoContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Item> Itens { get; set; }
    }
}
