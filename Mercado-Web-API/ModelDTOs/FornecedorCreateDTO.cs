using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.ModelDTOs {
    public class FornecedorCreateDTO {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Nome { get; set; }
    }
}
