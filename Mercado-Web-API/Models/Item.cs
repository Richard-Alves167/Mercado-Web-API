using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Mercado_Web_API.Models {
    public class Item {
        public Item(long idCompra, int idProduto, decimal preco, int quantidade) {
            IdCompra = idCompra;
            IdProduto = idProduto;
            Preco = preco;
            Quantidade = quantidade;
        }
        public long Id { get; set; }
        [Required]
        public long IdCompra { get; set; }
        public Compra Compra { get; set; }
        [Required]
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        public decimal Preco { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(99)]
        public int Quantidade { get; set; }
    }
}
