using System.ComponentModel.DataAnnotations;

namespace Mercado_Web_API.ModelDTOs {
    public class ItemReadDTO {
        public long Id { get; set; }
        public long CompraId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
