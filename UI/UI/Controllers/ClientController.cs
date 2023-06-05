using BL.DTO;
using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        readonly IClientService ClientService;
        public ClientController(IClientService clientService)
        {
            this.ClientService = clientService;
        }
        [HttpGet]
        public async Task<List<ClientDTO>> GetAll()
        {
            return ClientService.GetAllAsync().Result;
        }
        [HttpGet("get/{code}")]
        public async Task<ClientDTO> GetSingle(int code)
        {
            return ClientService.GetSingleAsync(code).Result;

        }

        [HttpDelete("delete/{code}")]
        public async Task<bool> DeleteSingle(int code)
        {
            return await ClientService.DeleteAsync(code);
           

        }
        [HttpPut("update/{code}")]
        public async Task<bool> UpdateSingle(int code, ClientDTO client)
        {
            return await ClientService.UpdateAsync(code, client);


        }

        [HttpPost("add")]
        public async Task<int> AddAsync(ClientDTO client)
        {
            return await ClientService.AddAsync(client);
        }
    }
}
