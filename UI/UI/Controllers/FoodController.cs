using BL;
using BL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {

        IFoodService FoodService;
        public FoodController(IFoodService foodService)
        {
            this.FoodService = foodService;
        }
        public async Task<List<FoodDTO>> GetAll()
        {
            return FoodService.GetAllAsync().Result;
        }
    }
}
