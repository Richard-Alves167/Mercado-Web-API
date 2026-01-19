using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.Interface_Repository {
    public interface IFornecedorRepository {
        public void Add(Fornecedor produto);
        public List<Fornecedor> GetAll();
        public Fornecedor GetById(int id);
        public List<Produto> GetAllProductsByFornecedorId(int id);
        public void AddFornecedorToProduto(int idFornecedor, int idProduto);
        public void RemoveFornecedorOfProduto(int idFornecedor, int idProduto);
        public void Delete(Fornecedor Fornecedor);
    }
}
