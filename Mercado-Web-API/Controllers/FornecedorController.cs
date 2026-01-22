using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mercado_Web_API.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase {
        private readonly ILogger<ClienteController> _logger;
        private IFornecedorService _fornecedorService;
        public FornecedorController(ILogger<ClienteController> logger, IFornecedorService fornecedorService) {
            _logger = logger;
            _fornecedorService = fornecedorService;
        }
        [HttpGet]
        public ActionResult<List<FornecedorReadDTO>> GetAll() {
            var fornecedoresDTO = _fornecedorService.GetAllFornecedores();
            if (!fornecedoresDTO.Any())
                return NoContent();
            return fornecedoresDTO;
        }
        [HttpGet("{id}")]
        public ActionResult<FornecedorReadDTO> GetById(int id) {
            var fornecedorDTO = _fornecedorService.GetFornecedorById(id);
            if (fornecedorDTO == null) {
                return NotFound();
            }
            return fornecedorDTO;
        }
        [HttpPost]
        public IActionResult Add(FornecedorCreateDTO fornecedorDTO) {
            var fornecedor = _fornecedorService.AddFornecedor(fornecedorDTO);
            return CreatedAtAction(nameof(GetById), new { id = fornecedor.Id }, fornecedor);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            bool deleted = _fornecedorService.DeleteFornecedor(id);
            if (!deleted) {
                return NotFound();
            }
            return NoContent();
        }
        [HttpGet("{fornecedorId}/produtos")]
        public ActionResult<List<Produto>> GetAllProdutosByFornedecorId(int fornecedorId) {
            var produtos = _fornecedorService.GetProdutosByIdFornecedor(fornecedorId);
            if (produtos == null) {
                return NotFound();
            }
            if (!produtos.Any()) {
                return NoContent();
            }
            return produtos;
        }
        [HttpPost("{fornecedorId}/produtos/{produtoId}")]
        public IActionResult AddProdutoToFornecedor(int fornecedorId, int produtoId) {
            var fornecedorProduto = _fornecedorService.AddProdutoToFornecedor(fornecedorId, produtoId);
            return CreatedAtAction(nameof(GetAllProdutosByFornedecorId), new { FornecedorId = fornecedorId, ProdutoId = produtoId }, fornecedorProduto);
        }
        [HttpDelete("{fornecedorId}/produtos/{produtoId}")]
        public IActionResult RemoveProdutoFromFornecedor(int fornecedorId, int produtoId) {
            bool removed = _fornecedorService.RemoveProdutoFromFornecedor(fornecedorId, produtoId);
            if (!removed) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
