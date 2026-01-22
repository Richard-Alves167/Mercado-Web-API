using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;
using Mercado_Web_API.Models.Relationships;

namespace Mercado_Web_API.Service {
    public class FornecedorService : IFornecedorService {
        private IFornecedorRepository _repos;
        public FornecedorService(IFornecedorRepository fornecedorRepository) {
            _repos = fornecedorRepository;
        }
        public Fornecedor AddFornecedor(FornecedorCreateDTO fornecedordto) {
            Fornecedor fornecedor = new Fornecedor(fornecedordto.Nome);
            _repos.Add(fornecedor);
            return fornecedor;
        }

        public bool DeleteFornecedor(int id) {
            Fornecedor fornecedor = _repos.GetById(id);
            if (fornecedor == null) {
                return false;
            }
            _repos.Delete(fornecedor);
            return true;
        }

        public List<FornecedorReadDTO> GetAllFornecedores() {
            List<Fornecedor> fornecedores = _repos.GetAll();
            List<FornecedorReadDTO> fornecedoresDTOs = fornecedores
                .Select(f => new FornecedorReadDTO {
                    Id = f.Id,
                    Nome = f.Nome
                })
                .ToList();
            return fornecedoresDTOs;
        }

        public FornecedorReadDTO GetFornecedorById(int id) {
            Fornecedor fornecedor = _repos.GetById(id);
            if (fornecedor == null) {
                return null;
            }
            FornecedorReadDTO fornecedorReadDTO = new FornecedorReadDTO {
                Id = fornecedor.Id,
                Nome = fornecedor.Nome
            };
            return fornecedorReadDTO;
        }
        public FornecedorProduto AddProdutoToFornecedor(int fornecedorId, int produtoId) {
            FornecedorProduto fornecedorProduto = new FornecedorProduto(fornecedorId, produtoId);
            _repos.AddFornecedorProduto(fornecedorProduto);
            return fornecedorProduto;
        }

        public List<Produto> GetProdutosByIdFornecedor(int fornecedorId) {
            Fornecedor fornecedor = _repos.GetById(fornecedorId);
            if (fornecedor == null) {
                return null;
            }
            List<Produto> produtos = _repos.GetAllProductsByFornecedorId(fornecedorId);
            return produtos;
        }

        public bool RemoveProdutoFromFornecedor(int fornecedorId, int produtoId) {
            FornecedorProduto fornecedorProduto = _repos.GetFornecedorProduto(fornecedorId, produtoId);
            if (fornecedorProduto == null) {
                return false;
            }
            _repos.RemoveFornecedorProduto(fornecedorProduto);
            return true;
        }
    }
}
