using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.Models {
    public class Compra {
        public Compra(int idCliente) {
            IdCliente = idCliente;
            Data = DateTime.Now;
        }
        [Required]
        public int IdCliente { get; set; }
        public DateTime Data { get; set; }
    }
}
