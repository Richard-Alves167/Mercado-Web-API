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
        [HttpPut("{id}/preco")]
        public ActionResult<ProdutoReadDTO> UpdatePreco(int id, [FromBody] decimal precoNovo) {
            try {
                var produtoDTO = _produtoService.UpdatePreco(id, precoNovo);
                if (produtoDTO == null) {
                    return NotFound();
                }
                return produtoDTO;
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}/quantidade")]
        public ActionResult<ProdutoReadDTO> UpdateQuantidade(int id, [FromBody] int quantidadeAdicionada) {
            try {
                var produtoDTO = _produtoService.UpdatePreco(id, quantidadeAdicionada);
                if (produtoDTO == null) {
                    return NotFound();
                }
                return produtoDTO;
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{idProduto}/fornecedores")]
        public ActionResult<List<FornecedorReadDTO>> GetFornecedoresByProdutoId(int idProduto) {
            var fornecedoresDTO = _produtoService.GetFornecedoresByIdProduto(idProduto);
            if (fornecedoresDTO == null) {
                return NotFound();
            }
            if (!fornecedoresDTO.Any()) {
                return NoContent();
            }
            return fornecedoresDTO;
        }
        [HttpGet("{idProduto}/fornecedores/{idFornecedor}")]
        public ActionResult<FornecedorProduto> GetFornecedorProduto(int idProduto, int idFornecedor) {
            var fornecedorDTO = _produtoService.GetProdutoFornecedor(idProduto, idFornecedor);
            if (fornecedorDTO == null) {
                return NotFound();
            }
            return fornecedorDTO;
        }
        [HttpPost("{idProduto}/fornecedores/{idFornecedor}")]
        public IActionResult AddProdutoToFornecededor(int idProduto, int idFornecedor) {
            var produtoFornecedor = _produtoService.AddProdutoToFornecedor(idProduto, idFornecedor);
            if (produtoFornecedor == null) {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetById), new { idProduto = produtoFornecedor.IdProduto, idFornecedor = produtoFornecedor .IdFornecedor}, produtoFornecedor);
        }
        [HttpDelete("{idProduto}/fornecedores/{idFornecedor}")]
        public IActionResult RemoveFornecedorFromProduto(int idProduto, int idFornecedor) {
            bool removedFornecedor = _produtoService.RemoveFornecedorFromProduto(idProduto, idFornecedor);
            if (!removedFornecedor) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
