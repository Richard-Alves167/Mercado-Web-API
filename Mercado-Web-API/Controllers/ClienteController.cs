using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mercado_Web_API.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase {
        private readonly ILogger<ClienteController> _logger;
        private IClienteRepository _clienteRepository;
        public ClienteController(ILogger<ClienteController> logger, IClienteRepository clienteRepository) {
            _logger = logger;
            _clienteRepository = clienteRepository;
        }
        [HttpGet(Name = "GetAllCliente")]
        public List<ClienteReadDTO> GetAll() {
            List<Cliente> clientes = _clienteRepository.GetAll();
            List<ClienteReadDTO> clientesDTO = [];
            foreach (Cliente cliente in clientes) {
                var clienteDTO = new ClienteReadDTO {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Email = cliente.Email
                };
                clientesDTO.Add(clienteDTO);
            }
            return clientesDTO;
        }
        [HttpGet("{id}")]
        public ClienteReadDTO GetById(int id) {
            Cliente cliente = _clienteRepository.GetById(id);
            var clienteDTO = new ClienteReadDTO {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email
            };
            return clienteDTO;
        }
        [HttpPost]
        public IActionResult Add(ClienteCreateDTO clienteDTO) {
            Cliente cliente = new Cliente(clienteDTO.Nome, clienteDTO.Email, clienteDTO.Senha);
            _clienteRepository.Add(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            _clienteRepository.Delete(id);
            return NoContent();
        }
    }
}
