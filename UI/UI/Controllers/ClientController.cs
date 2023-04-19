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
        [HttpGet("get/{id}")]
        public async Task<ClientDTO> GetSingle(string id)
        {
            return ClientService.GetSingleAsync(id).Result;

        }

        [HttpDelete("delete/{id}")]
        public async Task<bool> DeleteSingle(string id)
        {
            return await ClientService.DeleteAsync(id);
           

        }
        [HttpPut("update")]
        public async Task<bool> DeleteSingle(ClientDTO client)
        {
            return await ClientService.UpdateAsync(client);


        }

        [HttpPost("add")]
        public async Task<string> AddAsync(ClientDTO client)
        {
            return await ClientService.AddAsync(client);
        }
    }
}
