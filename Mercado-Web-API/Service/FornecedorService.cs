using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;
using Mercado_Web_API.Models.Relationships;

namespace Mercado_Web_API.Service {
    public class FornecedorService : IFornecedorService {
        IFornecedorRepository _repos;
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
        public FornecedorProduto AddProdutoToFornecedor(int idFornecedor, int idProduto) {
            FornecedorProduto fornecedorProduto = new FornecedorProduto(idFornecedor, idProduto);
            _repos.AddFornecedorProduto(fornecedorProduto);
            return fornecedorProduto;
        }

        public List<Produto> GetProdutosByIdFornecedor(int idFornecedor) {
            Fornecedor fornecedor = _repos.GetById(idFornecedor);
            if (fornecedor == null) {
                return null;
            }
            List<Produto> produtos = _repos.GetAllProductsByFornecedorId(idFornecedor);
            return produtos;
        }

        public bool RemoveProdutoFromFornecedor(int idFornecedor, int idProduto) {
            FornecedorProduto fornecedorProduto = _repos.GetFornecedorProduto(idFornecedor, idProduto);
            if (fornecedorProduto == null) {
                return false;
            }
            _repos.RemoveFornecedorProduto(fornecedorProduto);
            return true;
        }
    }
}
