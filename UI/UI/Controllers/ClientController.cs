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
            return await ClientService.GetAllAsync();
        }
        [HttpGet("get/{email}")]
        public async Task<ClientDTO?> GetSingle(string email)
        {
            return await ClientService.GetSingleAsync(email);

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
