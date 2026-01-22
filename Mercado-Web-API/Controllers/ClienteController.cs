using Mercado_Web_API.Data.Interface_Repository;
using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mercado_Web_API.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase {
        private readonly ILogger<ClienteController> _logger;
        private IClienteService _clienteService;
        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService) {
            _logger = logger;
            _clienteService = clienteService;
        }
        [HttpGet]
        public ActionResult<List<ClienteReadDTO>> GetAll() {
            var clientesDTO = _clienteService.GetAllClientes();
            if (!clientesDTO.Any())
                return NoContent();
            return clientesDTO;
        }
        [HttpGet("{id}")]
        public ActionResult<ClienteReadDTO> GetById(int id) {
            var clienteDTO = _clienteService.GetClienteById(id);
            if (clienteDTO == null) {
                return NotFound();
            }
            return clienteDTO;
        }
        [HttpPost]
        public IActionResult Add(ClienteCreateDTO clienteDTO) {
            var cliente = _clienteService.AddCliente(clienteDTO);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }
        [HttpGet("{id}/compras")]
        public ActionResult<List<CompraReadDTO>> GetAllComprasByIdCliente(int id) {
            var compraDTOs = _clienteService.GetAllComprasByIdCliente(id);
            if (compraDTOs == null) {
                return NotFound();
            }
            if (!compraDTOs.Any()) {
                return NoContent();
            }
            return compraDTOs;
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            bool deleted = _clienteService.DeleteCliente(id);
            if (!deleted) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
