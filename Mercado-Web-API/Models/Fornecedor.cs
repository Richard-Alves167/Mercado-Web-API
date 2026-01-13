using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.Models {
    public class Fornecedor {
        public Fornecedor(string nome) {
            Nome = nome;
        }
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
