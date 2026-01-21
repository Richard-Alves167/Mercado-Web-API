using Mercado_Web_API.Models.Relationships;
using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.Interface_Repository {
    public interface IProdutoRepository {
        public void Add(Produto produto);
        public List<Produto> GetAll();
        public Produto GetById(int id);
        public void UpdateEstoque(Produto produto, int quantidadeEstoqueAdicionada);
        public void UpdatePreco(Produto produto, decimal precoNovo);
        public List<Fornecedor> GetAllFornecedoresByProdutoId(int idProduto);
        public void AddFornecedorProduto(FornecedorProduto fornecedorProduto);
        public FornecedorProduto GetFornecedorProduto(int idFornecedor, int idProduto);
        public void RemoveFornecedorProduto(FornecedorProduto fornecedorProduto);
        public void Delete(Produto produto);
    }
}
