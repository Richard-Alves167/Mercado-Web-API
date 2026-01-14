using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.Models {
    public class Cliente {
        public Cliente(string nome, string email, string senha) {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(20)]
        public string Senha { get; set; }
        public ICollection<Compra> Compras { get; set; }
    }
}
