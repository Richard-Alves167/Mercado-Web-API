using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Mercado_Web_API.Models {
    public class Compra {
        public Compra(int clienteId) {
            ClienteId = clienteId;
            Data = DateTime.Now;
        }
        public long Id { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public ICollection<Item> Itens { get; set; }
    }
}
