namespace DAL.Interfaces
{
    public interface IClientRepository : IRepsitory<Client, string>
    {
        Task<Client?> GetSingleAsync(int code);
    }
}
