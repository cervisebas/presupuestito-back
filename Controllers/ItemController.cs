using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemService itemService;

        public ItemController(ItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpPost]
        public async Task CreateItem([FromBody] ItemRequestDto itemRequestDto)
        {
            await itemService.CreateItem(itemRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateItem(int id, [FromBody] ItemRequestDto itemRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await itemService.UpdateItem(id, itemRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemResponseDto>> GetItemById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var item = await itemService.GetItemById(id);
            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemResponseDto>>> GetAllItems()
        {
            return await itemService.GetAllItems();
        }

        [HttpDelete("{id}")]
        public async Task DeleteItem(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await itemService.DeleteItem(id);
        }

    }
}
