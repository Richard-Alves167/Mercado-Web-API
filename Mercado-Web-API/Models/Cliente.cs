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
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
