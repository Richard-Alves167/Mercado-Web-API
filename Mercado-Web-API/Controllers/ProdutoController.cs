using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;
using Mercado_Web_API.Models.Relationships;
using Microsoft.AspNetCore.Mvc;

namespace Mercado_Web_API.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase {
        private IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService) {
            _produtoService = produtoService;
        }
        [HttpGet]
        public ActionResult<List<ProdutoReadDTO>> GetAll() {
            var produtosDTO = _produtoService.GetAllProdutos();
            if (!produtosDTO.Any())
                return NoContent();
            return produtosDTO;
        }
        [HttpGet("{id}")]
        public ActionResult<ProdutoReadDTO> GetById(int id) {
            var produtoDTO = _produtoService.GetProdutoById(id);
            if (produtoDTO == null) {
                return NotFound();
            }
            return produtoDTO;
        }
        [HttpPost]
        public IActionResult Add(ProdutoCreateDTO produtoDTO) {
            var produto = _produtoService.AddProduto(produtoDTO);
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            bool deleted = _produtoService.DeleteProduto(id);
            if (!deleted) {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPatch("{id}/preco")]
        public ActionResult<ProdutoReadDTO> UpdatePreco(int id, [FromBody] ProdutoUpdatePrecoDTO produtoPrecoDTO) {
            try {
                var produtoDTO = _produtoService.UpdatePreco(id, produtoPrecoDTO.Preco);
                if (produtoDTO == null) {
                    return NotFound();
                }
                return NoContent();
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("{id}/quantidade")]
        public ActionResult<ProdutoReadDTO> UpdateQuantidade(int id, [FromBody] ProdutoUpdateQuantidadeDTO produtoQuantidadeDTO) {
            try {
                var produtoDTO = _produtoService.UpdateQuantidade(id, produtoQuantidadeDTO.Quantidade);
                if (produtoDTO == null) {
                    return NotFound();
                }
                return NoContent();
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{produtoId}/fornecedores")]
        public ActionResult<List<FornecedorReadDTO>> GetFornecedoresByProdutoId(int produtoId) {
            var fornecedoresDTO = _produtoService.GetFornecedoresByIdProduto(produtoId);
            if (fornecedoresDTO == null) {
                return NotFound();
            }
            if (!fornecedoresDTO.Any()) {
                return NoContent();
            }
            return fornecedoresDTO;
        }
        [HttpGet("{produtoId}/fornecedores/{fornecedorId}")]
        public ActionResult<FornecedorProduto> GetFornecedorProduto(int produtoId, int fornecedorId) {
            var fornecedorDTO = _produtoService.GetProdutoFornecedor(fornecedorId, produtoId);
            if (fornecedorDTO == null) {
                return NotFound();
            }
            return fornecedorDTO;
        }
        [HttpPost("{produtoId}/fornecedores/{fornecedorId}")]
        public IActionResult AddProdutoToFornecededor(int produtoId, int fornecedorId) {
            var produtoFornecedor = _produtoService.AddProdutoToFornecedor(fornecedorId, produtoId);
            if (produtoFornecedor == null) {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{produtoId}/fornecedores/{fornecedorId}")]
        public IActionResult RemoveFornecedorFromProduto(int produtoId, int fornecedorId) {
            bool removedFornecedor = _produtoService.RemoveFornecedorFromProduto(fornecedorId, produtoId);
            if (!removedFornecedor) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
