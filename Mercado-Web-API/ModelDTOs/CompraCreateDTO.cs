using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.ModelDTOs {
    public class CompraCreateDTO {
        [Required]
        public int ClienteId { get; set; }
    }
}
