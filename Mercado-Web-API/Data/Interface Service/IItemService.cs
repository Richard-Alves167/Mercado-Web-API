using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.Interface_Service {
    public interface IItemService {
        public ItemReadDTO CreateItemToCompra(ItemCreateDTO itemdto);
        public ItemReadDTO GetItemById(long id);
        public List<ItemReadDTO> GetAllItens();
        public bool DeleteItem(long id);
    }
}
