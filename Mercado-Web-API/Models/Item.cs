using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.Models {
    public class Item {
        public Item(int idCompra, int idProduto, decimal preco, int quantidade) {
            IdCompra = idCompra;
            IdProduto = idProduto;
            Preco = preco;
            Quantidade = quantidade;
        }
        public int Id { get; set; }
        [Required]
        public int IdCompra { get; set; }
        [Required]
        public int IdProduto { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
