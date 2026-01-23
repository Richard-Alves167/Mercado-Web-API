using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace Mercado_Web_API.Service {
    public class CompraService : ICompraService {
        private ICompraRepository _repos;
        private IClienteRepository _clienteRepository;
        public CompraService(ICompraRepository repos, IClienteRepository clienteRepository) {
            _repos = repos;
            _clienteRepository = clienteRepository;
        }

        public Compra CreateCompra(CompraCreateDTO compradto) {
            Cliente cliente = _clienteRepository.GetById(compradto.ClienteId);
            if (cliente == null) {
                return null;
            }
            Compra compra = new Compra(compradto.ClienteId);
            _repos.Add(compra);
            return compra;
        }

        public List<CompraReadDTO> GetAllCompras() {
            List<Compra> compras = _repos.GetAll();
            List<CompraReadDTO> comprasDTOs = compras.Select(c => new CompraReadDTO {
                Id = c.Id,
                ClienteId = c.ClienteId,
                Data = c.Data
            }).ToList();
            return comprasDTOs;
        }

        public CompraReadDTO GetCompraById(long id) {
            Compra compra = _repos.GetById(id);
            if (compra == null) {
                return null;
            }
            CompraReadDTO compraDTO = new CompraReadDTO {
                Id = compra.Id,
                ClienteId = compra.ClienteId,
                Data = compra.Data
            };
            return compraDTO;
        }

        public List<ItemReadDTO> GetItensByCompraId(long compraId) {
            Compra compra = _repos.GetById(compraId);
            if (compra == null) {
                return null;
            }
            List<Item> itens = _repos.GetItensByCompraId(compraId);
            List<ItemReadDTO> itensDTOs = itens.Select(i => new ItemReadDTO {
                Id = i.Id,
                CompraId = i.CompraId,
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade,
                Preco = i.Preco
            }).ToList();
            return itensDTOs;
        }
        public bool DeleteCompra(long id) {
            Compra compra = _repos.GetById(id);
            if (compra == null) {
                return false;
            }
            _repos.Delete(compra);
            return true;
        }
    }
}
