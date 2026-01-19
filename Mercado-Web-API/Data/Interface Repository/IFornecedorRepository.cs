using Mercado_Web_API.Models;
using Mercado_Web_API.Models.Relationships;

namespace Mercado_Web_API.Data.Interface_Repository {
    public interface IFornecedorRepository {
        public void Add(Fornecedor produto);
        public List<Fornecedor> GetAll();
        public Fornecedor GetById(int id);
        public List<Produto> GetAllProductsByFornecedorId(int idFornecedor);
        public void AddFornecedorProduto(FornecedorProduto fornecedorProduto);
        public FornecedorProduto GetFornecedorProduto(int idFornecedor, int idProduto);
        public void RemoveFornecedorProduto(FornecedorProduto fornecedorProduto);
        public void Delete(Fornecedor Fornecedor);
    }
}
