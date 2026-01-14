using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Mercado_Web_API.Models {
    public class Compra {
        public Compra(int idCliente) {
            IdCliente = idCliente;
            Data = DateTime.Now;
        }
        public long Id { get; set; }
        [Required]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public ICollection<Item> Itens { get; set; }
    }
}
