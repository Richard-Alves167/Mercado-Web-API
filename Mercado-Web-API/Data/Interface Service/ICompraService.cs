using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.Interface_Service {
    public interface ICompraService {
        public Compra CreateCompra(CompraCreateDTO compradto);
        public CompraReadDTO GetCompraById(long id);
        public List<CompraReadDTO> GetAllCompras();
        public List<ItemReadDTO> GetItensByCompraId(long compraId);
        public bool DeleteCompra(long id);
    }
}
