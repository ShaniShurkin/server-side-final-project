using BL.DTO;
using BL;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using BL.Interfaces;

namespace UI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        readonly IClientService clientService;
        readonly IFoodService foodService;
        readonly IMenuService menuService;
        public MenuController(IClientService clientService, IFoodService foodService, IMenuService menuService) 
        {
            this.clientService = clientService;
            this.foodService=foodService;
            this.menuService=menuService;   
        }
        [HttpPost("get-menu/{code}")]
        public async Task<string> GetMenu(int code)
        {
            List<FoodDTO> foodList = await foodService.GetAllAsync();
            ClientDTO? client = await clientService.GetSingleAsync(code);
            if (client == null)
            {
                return "there is a problem";
            }
            
            ////try antd catch
            client.Menu = await menuService.CreateMenu(foodList, client);
            return client.Menu;
        }
        [HttpPost("save/{code}")]
        public async Task<bool> CreateMenu([FromBody]object menu, int code)
        {//, [FromBody]string menu
            bool res =  await menuService.UpdateMenu(code, menu.ToString());
            return res;
        }

    }
}
