using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.ModelDTOs {
    public class ClienteCreateDTO {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        [MinLength(10)]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string Senha { get; set; }
    }
}
