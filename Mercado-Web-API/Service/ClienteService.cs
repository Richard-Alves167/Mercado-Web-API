using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.Data.RepositoryEF;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;

namespace Mercado_Web_API.Service {
    public class ClienteService : IClienteService {
        IClienteRepository _repos;
        public ClienteService(IClienteRepository clienteRepository) {
            _repos = clienteRepository;
        }
        public Cliente AddCliente(ClienteCreateDTO clienteDTO) {
            Cliente cliente = new Cliente(clienteDTO.Nome, clienteDTO.Email, clienteDTO.Senha);
            _repos.Add(cliente);
            return cliente;
        }
        public ClienteReadDTO GetClienteByEmailAndSenha(string email, string senha) {
            Cliente cliente = _repos.GetByEmailAndSenha(email, senha);
            ClienteReadDTO clienteReadDTO = new ClienteReadDTO {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email
            };
            return clienteReadDTO;
        }
        public ClienteReadDTO GetClienteById(int id) {
            Cliente cliente = _repos.GetById(id);
            ClienteReadDTO clienteReadDTO = new ClienteReadDTO {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email
            };
            return clienteReadDTO;
        }
        public List<ClienteReadDTO> GetAllClientes() {
            List<Cliente> clientes = _repos.GetAll();
            List<ClienteReadDTO> clientesDTO = clientes.Select(cliente => new ClienteReadDTO {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email
            }).ToList();
            return clientesDTO;
        }
        public bool DeleteCliente(int id) {
            Cliente cliente = _repos.GetById(id);
            if (cliente == null) {
                return false;
            }
            _repos.Delete(cliente);
            return true;
        }
    }
}
