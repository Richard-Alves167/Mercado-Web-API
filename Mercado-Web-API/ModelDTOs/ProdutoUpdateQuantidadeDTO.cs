using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.ModelDTOs {
    public class ProdutoUpdateQuantidadeDTO {
        [Required]
        [Range(1, 9999, ErrorMessage = "A quantidade a ser adicionada deve ser maior que zero")]
        public int Quantidade { get; set; }
    }
}
