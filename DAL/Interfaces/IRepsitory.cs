namespace DAL.Interfaces
{
    public interface IRepsitory<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetSingleAsync(string id);
        Task<string> AddAsync(T objectToAdd);
        Task<bool> UpdatAsync(string id, T objectToUpdate);
        Task<bool> DeleteAsync(string id);
    }
}
