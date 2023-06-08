namespace BL.Interfaces
{
    public interface IClientService : IService<ClientDTO, string>
    {
        Task<ClientDTO?> GetSingleAsync(int code);
    }
}
