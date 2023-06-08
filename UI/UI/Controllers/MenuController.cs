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
        public MenuController(IClientService clientService, IFoodService foodService)
        {
            this.clientService = clientService;
            this.foodService=foodService;
        }
        [HttpGet("get-menu/{code}")]
        public async Task<string> GetSimplex(int code)
        {
            List<FoodDTO> foodList = await foodService.GetAllAsync();
            ClientDTO? client = await clientService.GetSingleAsync(code);
            if (client == null)
            {
                return "there is a problem";
            }
            
            ////try antd catch
            client.Menu = await MenuPlanning.CreateMenu(foodList, client);
            return client.Menu;
        }
    }
}
