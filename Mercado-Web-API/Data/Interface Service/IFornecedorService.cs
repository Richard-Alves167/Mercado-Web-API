using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;
using Mercado_Web_API.Models.Relationships;

namespace Mercado_Web_API.Data.Interface_Service {
    public interface IFornecedorService {
        public Fornecedor AddFornecedor(FornecedorCreateDTO fornecedordto);
        public FornecedorReadDTO GetFornecedorById(int id);
        public List<FornecedorReadDTO> GetAllFornecedores();
        public FornecedorProduto AddProdutoToFornecedor(int idFornecedor, int idProduto);
        public bool RemoveProdutoFromFornecedor(int idFornecedor, int idProduto);
        public List<ProdutoReadDTO> GetProdutosByIdFornecedor(int idFornecedor);
        public bool DeleteFornecedor(int id);
    }
}
