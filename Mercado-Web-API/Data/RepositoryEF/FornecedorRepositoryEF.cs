using System.Linq;
using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Models;
using Mercado_Web_API.Models.Relationships;

namespace Mercado_Web_API.Data.RepositoryEF {
    public class FornecedorRepositoryEF : IFornecedorRepository {
        private MercadoContext _context;
        public FornecedorRepositoryEF(MercadoContext context) {
            _context = context;
        }
        public void Add(Fornecedor fornecedor) {
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();
        }
        public Fornecedor GetById(int id) {
            return _context.Fornecedores.FirstOrDefault(f => f.Id == id);
        }

        public List<Fornecedor> GetAll() {
            return _context.Fornecedores.ToList();
        }

        public void AddFornecedorProduto(FornecedorProduto fornecedorProduto) {
            _context.FornecedoresProdutos.Add(fornecedorProduto);
            _context.SaveChanges();
        }
        public FornecedorProduto GetFornecedorProduto(int idFornecedor, int idProduto) {
            return _context.FornecedoresProdutos.FirstOrDefault(fp => fp.IdFornecedor == idFornecedor && fp.IdProduto == idFornecedor);
        }

        public List<Produto> GetAllProductsByFornecedorId(int idFornecedor) {
            return _context.FornecedoresProdutos.Where(fp => fp.IdFornecedor == idFornecedor).Select(fp => fp.Produto).ToList() ;
        }

        public void RemoveFornecedorProduto(FornecedorProduto fornecedorProduto) {
            _context.FornecedoresProdutos.Remove(fornecedorProduto);
            _context.SaveChanges();
        }

        public void Delete(Fornecedor Fornecedor) {
            _context.Fornecedores.Remove(Fornecedor);
            _context.SaveChanges();
        }
    }
}
