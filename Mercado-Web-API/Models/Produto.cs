using System.ComponentModel.DataAnnotations;
using Azure;
using Mercado_Web_API.Models.Relationships;

namespace Mercado_Web_API.Models {
    public class Produto {
        public Produto(string nome, decimal preco, int estoque) {
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
        }
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Range(0.01, 9999, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }
        public string Imagem { get; set; } = "https://s3.wasabisys.com/horseplace.smserver.com.br/img/products/default.jpg";
        [Required]
        [Range(0.01, 9999, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int Estoque { get; set; }
        public List<FornecedorProduto> FornecedorProdutos { get; } = [];
        public List<Fornecedor> Fornecedores { get; } = [];
        public ICollection<Item> Itens { get; set; }
    }
}
