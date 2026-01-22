using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.Interface_Repository {
    public interface ICompraRepository {
        public void Add(Compra compra);
        public List<Compra> GetAll();
        public Compra GetById(long id);
        public List<Item> GetItensByCompraId(long compraId);
        public void Delete(Compra compra);
    }
}
