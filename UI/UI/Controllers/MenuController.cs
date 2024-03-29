﻿using BL.DTO;
using BL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
       // readonly IClientService clientService;
        readonly IFoodService foodService;
        readonly IMenuService menuService;
        public MenuController(IClientService clientService, IFoodService foodService, IMenuService menuService)
        {
            //this.clientService = clientService;
            this.foodService = foodService;
            this.menuService = menuService;
        }
        [HttpGet("get-menu/{code}")]
        public async Task<string> GetMenu(int code)
        {
            List<FoodDTO> foodList = await foodService.GetAllAsync();
           // ClientDTO? client = await clientService.GetSingleAsync(code);
            //if (client == null)
            //{
            //    return "there is a problem";
            //}

            ////try antd catch
            //client.Menu = await menuService.CreateMenu(foodList, client);
            string menu = await menuService.CreateMenu(foodList, code);
            return menu;
        }
        [HttpPost("save/{code}")]
        public async Task<bool> UpdateMenu([FromBody] object menu, int code)
        {//, [FromBody]string menu
            bool res = await menuService.UpdateMenu(code, menu.ToString());
            return res;
        }

    }
}
