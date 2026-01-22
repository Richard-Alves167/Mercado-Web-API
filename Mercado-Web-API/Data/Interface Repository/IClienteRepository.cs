using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.Interface_Repository {
    public interface IClienteRepository {
        public void Add(Cliente cliente);
        public List<Cliente> GetAll();
        public Cliente GetById(int id);
        public Cliente GetByEmailAndSenha(string email, string senha);
        public List<Compra> GetComprasByClienteId(int clienteId);
        public void Delete(Cliente cliente);
    }
}
