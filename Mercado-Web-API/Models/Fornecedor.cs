using System.ComponentModel.DataAnnotations;
using Mercado_Web_API.Models.Relationships;

namespace Mercado_Web_API.Models {
    public class Fornecedor {
        public Fornecedor(string nome) {
            Nome = nome;
        }
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Nome { get; set; }
        public List<FornecedorProduto> FornecedorProdutos { get; } = [];
        public List<Produto> Produtos { get; } = [];

    }
}
