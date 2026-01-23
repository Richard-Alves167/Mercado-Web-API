using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;

namespace Mercado_Web_API.Service {
    public class ItemService : IItemService {
        private IItemRepository _repos;
        private ICompraRepository _compraRepository;
        private IProdutoRepository _produtoRepository;
        public ItemService(IItemRepository itemRepository, ICompraRepository compraRepository, IProdutoRepository produtoRepository) {
            _repos = itemRepository;
            _compraRepository = compraRepository;
            _produtoRepository = produtoRepository;
        }

        public ItemReadDTO CreateItemToCompra(ItemCreateDTO itemdto) {
            Compra compra = _compraRepository.GetById(itemdto.CompraId);
            if (compra == null) {
                return null;
            }
            Produto produto = _produtoRepository.GetById(itemdto.ProdutoId);
            if (compra == null) {
                return null;
            }
            Item item = new Item(itemdto.CompraId, itemdto.ProdutoId, produto.Preco, itemdto.Quantidade);
            _repos.Add(item);
            return new ItemReadDTO {
                Id = item.Id,
                CompraId = item.CompraId,
                ProdutoId = item.ProdutoId,
                Preco = item.Preco,
                Quantidade = item.Quantidade
            };
        }

        public List<ItemReadDTO> GetAllItens() {
            List<Item> itens = _repos.GetAll();
            List<ItemReadDTO> itensDTOs = itens.Select(i => new ItemReadDTO {
                Id = i.Id,
                CompraId = i.CompraId,
                ProdutoId = i.ProdutoId,
                Preco = i.Preco,
                Quantidade = i.Quantidade
            }).ToList();
            return itensDTOs;
        }

        public ItemReadDTO GetItemById(long id) {
            Item iten = _repos.GetById(id);
            if (iten == null) {
                return null;
            }
            ItemReadDTO itemDTO = new ItemReadDTO {
                Id = iten.Id,
                CompraId = iten.CompraId,
                ProdutoId = iten.ProdutoId,
                Preco = iten.Preco,
                Quantidade = iten.Quantidade
            };
            return itemDTO;
        }
        public bool DeleteItem(long id) {
            Item iten = _repos.GetById(id);
            if (iten == null) {
                return false;
            }
            _repos.Delete(iten);
            return true;
        }
    }
}
