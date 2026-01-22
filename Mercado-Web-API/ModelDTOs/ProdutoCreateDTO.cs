using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.ModelDTOs {
    public class ProdutoCreateDTO {
        [Required]
        public string Nome { get; set; }
        [Required]
        [Range(0.01, 9999, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }
        [Required]
        [Range(0.01, 9999, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int Estoque { get; set; }
        public string Imagem { get; set; } = "https://s3.wasabisys.com/horseplace.smserver.com.br/img/products/default.jpg";
    }
}
