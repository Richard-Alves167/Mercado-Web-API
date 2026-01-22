using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Mercado_Web_API.Models {
    public class Item {
        public Item(long compraId, int produtoId, decimal preco, int quantidade) {
            CompraId = compraId;
            ProdutoId = produtoId;
            Preco = preco;
            Quantidade = quantidade;
        }
        public long Id { get; set; }
        [Required]
        public long CompraId { get; set; }
        public Compra Compra { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        [Required]
        [Range(0.01, 9999, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }
        [Required]
        [Range(0.01, 9999, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int Quantidade { get; set; }
    }
}
