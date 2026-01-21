using Mercado_Web_API.Models.Relationships;
using Mercado_Web_API.Models;
using Mercado_Web_API.ModelDTOs;

namespace Mercado_Web_API.Data.Interface_Service {
    public interface IProdutoService {
        public Produto AddProduto(ProdutoCreateDTO produtodto);
        public ProdutoReadDTO GetProdutoById(int id);
        public List<ProdutoReadDTO> GetAllProdutos();
        public ProdutoReadDTO UpdatePreco(int idProduto, decimal precoNovo);
        public ProdutoReadDTO UpdateQuantidade(int idProduto, int quantidadeAdicionada);
        public FornecedorProduto AddProdutoToFornecedor(int idFornecedor, int idProduto);
        public FornecedorProduto GetProdutoFornecedor(int idFornecedor, int idProduto);
        public bool RemoveFornecedorFromProduto(int idFornecedor, int idProduto);
        public List<FornecedorReadDTO> GetFornecedoresByIdProduto(int idProduto);
        public bool DeleteProduto(int id);
    }
}
