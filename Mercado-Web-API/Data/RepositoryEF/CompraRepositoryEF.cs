using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.RepositoryEF {
    public class CompraRepositoryEF : ICompraRepository {
        private MercadoContext _context;
        public CompraRepositoryEF(MercadoContext context) {
            _context = context;
        }
        public void Add(Compra compra) {
            _context.Compras.Add(compra);
            _context.SaveChanges();
        }

        public List<Compra> GetAll() {
            var compras = _context.Compras.ToList();
            return compras;
        }

        public Compra GetById(long id) {
            var compra = _context.Compras.FirstOrDefault(c => c.Id == id);
            return compra;
        }

        public List<Item> GetItensByCompraId(long compraId) {
            var itens = _context.Itens.Where(i => i.CompraId == compraId).ToList();
            return itens;
        }
        public void Delete(Compra compra) {
            _context.Compras.Remove(compra);
            _context.SaveChanges();
        }
    }
}
