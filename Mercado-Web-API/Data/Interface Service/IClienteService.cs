using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;

namespace Mercado_Web_API.Data.Interface_Service {
    public interface IClienteService {
        public Cliente AddCliente(ClienteCreateDTO clientedto);
        public ClienteReadDTO GetClienteByEmailAndSenha(string email, string senha);
        public ClienteReadDTO GetClienteById(int id);
        public List<ClienteReadDTO> GetAllClientes();
        public bool DeleteCliente(int id);
    }
}
