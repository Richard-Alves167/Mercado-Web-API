using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.ModelDTOs {
    public class ProdutoCreateDTO {
        [Required]
        public string Nome { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(1000)]
        public decimal Preco { get; set; }
        [Required]
        [MinLength(1)]
        public int Estoque { get; set; }
        public string Imagem { get; set; } = "https://s3.wasabisys.com/horseplace.smserver.com.br/img/products/default.jpg";
    }
}
