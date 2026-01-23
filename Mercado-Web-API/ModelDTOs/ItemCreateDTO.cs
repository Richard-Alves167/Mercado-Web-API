using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.ModelDTOs {
    public class ItemCreateDTO {
        [Required]
        public long CompraId { get; set; }
        [Required]
        public int ProdutoId { get; set; }
        [Required]
        [Range(0.01, 9999, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Preco { get; set; }
        [Required]
        [Range(1, 9999, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int Quantidade { get; set; }
    }
}
