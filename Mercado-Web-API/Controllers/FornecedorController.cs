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
        [HttpGet("{idFornecedor}/produtos")]
        public ActionResult<List<Produto>> GetAllProdutosByFornedecorId(int idFornecedor) {
            var produtos = _fornecedorService.GetProdutosByIdFornecedor(idFornecedor);
            if (produtos == null) {
                return NotFound();
            }
            if (!produtos.Any()) {
                return NoContent();
            }
            return produtos;
        }
        [HttpPost("{idFornecedor}/produtos/{idProduto}")]
        public IActionResult AddProdutoToFornecedor(int idFornecedor, int idProduto) {
            var fornecedorProduto = _fornecedorService.AddProdutoToFornecedor(idFornecedor, idProduto);
            return CreatedAtAction(nameof(GetAllProdutosByFornedecorId), new { idFornecedor = idFornecedor }, fornecedorProduto);
        }
        [HttpDelete("{idFornecedor}/produtos/{idProduto}")]
        public IActionResult RemoveProdutoFromFornecedor(int idFornecedor, int idProduto) {
            bool removed = _fornecedorService.RemoveProdutoFromFornecedor(idFornecedor, idProduto);
            if (!removed) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
