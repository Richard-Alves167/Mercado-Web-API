using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.Interface_Repository {
    public interface IItemRepository {
        public void Add(Item item);
        public List<Item> GetAll();
        public Item GetById(long id);
        public void Delete(Item item);
    }
}
