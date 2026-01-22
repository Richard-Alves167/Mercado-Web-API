using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercado_Web_API.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CompraController : ControllerBase {
        private ICompraService _compraService;
        public CompraController(ICompraService compraService) {
            _compraService = compraService;
        }
        [HttpGet]
        public ActionResult<List<CompraReadDTO>> GetAll() {
            return _compraService.GetAllCompras();
        }
        [HttpGet("{id}")]
        public ActionResult<CompraReadDTO> GetById(long id) {
            var compraDTO = _compraService.GetCompraById(id);
            if (compraDTO == null) {
                return NotFound();
            }
            return compraDTO;
        }
        [HttpPost]
        public ActionResult<CompraReadDTO> Add(CompraCreateDTO compraDTO) {
            var compra = _compraService.CreateCompra(compraDTO);
            var compraReadDTO = new CompraReadDTO {
                Id = compra.Id,
                Data = compra.Data,
                ClienteId = compra.ClienteId
            };
            return compraReadDTO;
        }
        [HttpGet("{id}/itens")]
        public ActionResult<List<Item>> GetItensByCompraId(long id) {
            var itensDTO = _compraService.GetItensByCompraId(id);
            if (itensDTO == null) {
                return NotFound();
            }
            return itensDTO;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(long id) {
            var deleted = _compraService.DeleteCompra(id);
            if (!deleted) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
