﻿using BL;
using BL.DTO;
using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        readonly IFoodService FoodService;
        public FoodController(IFoodService foodService)
        {
            this.FoodService = foodService;
        }
        [HttpGet]
        public async Task<List<FoodDTO>> GetAll()
        {
            return FoodService.GetAllAsync().Result;
        }
        [HttpGet("get/{code}")]
        public async Task<FoodDTO> GetSingle(int code)
        {
            return await FoodService.GetSingleAsync(code);

        }
        //[HttpPost("simplex")]
        //public async Task<string> CreateMealStructure(string jsonStracture)
        //{

        //}
        
    }
}
