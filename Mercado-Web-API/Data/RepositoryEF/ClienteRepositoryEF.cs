using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.RepositoryEF {
    public class ClienteRepositoryEF : IClienteRepository {
        private MercadoContext _context;
        public ClienteRepositoryEF(MercadoContext context) {
            _context = context;
        }
        public void Add(Cliente cliente) {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> GetAll() {
            return _context.Clientes.ToList();
        }
        public Cliente GetById(int id) {
            return _context.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public Cliente GetByEmailAndSenha(string email, string senha) {
            return _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);
        }

        public void Delete(Cliente cliente) {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }
}
