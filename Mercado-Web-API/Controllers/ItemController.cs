using Mercado_Web_API.Data.Interface_Service;
using Mercado_Web_API.ModelDTOs;
using Mercado_Web_API.Models;
using Mercado_Web_API.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mercado_Web_API.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase {

        private IItemService _itemService;
        public ItemController(IItemService itemService) {
            _itemService = itemService;
        }

        [HttpGet]
        public ActionResult<List<ItemReadDTO>> GetAll() {
            List<ItemReadDTO> itensDTO = _itemService.GetAllItens();
            if (!itensDTO.Any())
                return NoContent();
            return itensDTO;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemReadDTO> GetById(long id) {
            ItemReadDTO itemDTO = _itemService.GetItemById(id);
            if (itemDTO == null) {
                return NotFound();
            }
            return itemDTO;
        }

        [HttpPost]
        public IActionResult CreateItem(ItemCreateDTO itemDTO) {
            var item = _itemService.CreateItemToCompra(itemDTO);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) {
            bool deleted = _itemService.DeleteItem(id);
            if (!deleted) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
