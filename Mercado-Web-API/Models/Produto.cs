using System.ComponentModel.DataAnnotations;

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
        public decimal Preco { get; set; }
        public string Imagem { get; set; } = "https://s3.wasabisys.com/horseplace.smserver.com.br/img/products/default.jpg";
        [Required]
        public int Estoque { get; set; }
    }
}
