using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.Interface_Repository {
    public interface ICompraRepository {
        public void Add(Compra compra);
        public List<Compra> GetAll();
        public Compra GetById(int id);
        public List<Compra> GetComprasByClienteId(int clienteId);
        public List<Item> GetItensByCompraId(int compraId);
        public void Delete(Compra compra);
    }
}
