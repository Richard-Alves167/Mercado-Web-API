using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.RepositoryEF {
    public class ItemRepositoryEF : IItemRepository {
        private MercadoContext _context;
        public ItemRepositoryEF(MercadoContext context) {
            _context = context;
        }

        public void Add(Item item) {
            _context.Itens.Add(item);
            _context.SaveChanges();
        }

        public List<Item> GetAll() {
            List<Item> itens = _context.Itens.ToList();
            return itens;
        }

        public Item GetById(long id) {
            Item item = _context.Itens.FirstOrDefault(i => i.Id == id);
            return item;
        }
        public void Delete(Item item) {
            _context.Itens.Remove(item);
            _context.SaveChanges();
        }
    }
}
