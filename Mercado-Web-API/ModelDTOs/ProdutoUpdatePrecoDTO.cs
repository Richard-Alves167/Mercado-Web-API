using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.ModelDTOs {
    public class ProdutoUpdatePrecoDTO {
        [Required]
        [Range(0.01, 9999, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }
    }
}
