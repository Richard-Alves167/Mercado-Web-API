using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Models;
using Mercado_Web_API.Models.Relationships;

namespace Mercado_Web_API.Data.RepositoryEF {
    public class ProdutoRepositoryEF : IProdutoRepository {
        private MercadoContext _context;
        public ProdutoRepositoryEF(MercadoContext context) {
            _context = context;
        }
        public void Add(Produto produto) {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }
        public List<Produto> GetAll() {
            return _context.Produtos.ToList();
        }
        public Produto GetById(int id) {
            return _context.Produtos.FirstOrDefault(p => p.Id == id);
        }
        public void UpdateEstoque(Produto produto, int quantidadeEstoqueAdicionada) {
            produto.Estoque += quantidadeEstoqueAdicionada;
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }
        public void UpdatePreco(Produto produto, decimal precoNovo) {
            produto.Preco = precoNovo;
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }
        public List<Fornecedor> GetAllFornecedoresByProdutoId(int idProduto) {
            return _context.FornecedoresProdutos.Where(fp => fp.IdProduto == idProduto).Select(fp => fp.Fornecedor).ToList();
        }
        public void AddFornecedorProduto(FornecedorProduto fornecedorProduto) {
            _context.FornecedoresProdutos.Add(fornecedorProduto);
            _context.SaveChanges();
        }
        public FornecedorProduto GetFornecedorProduto(int idFornecedor, int idProduto) {
            return _context.FornecedoresProdutos.FirstOrDefault(fp => fp.IdFornecedor == idFornecedor && fp.IdProduto == idProduto);
        }
        public void RemoveFornecedorProduto(FornecedorProduto fornecedorProduto) {
            _context.FornecedoresProdutos.Remove(fornecedorProduto);
            _context.SaveChanges();
        }
        public void Delete(Produto produto) {
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }
    }
}
