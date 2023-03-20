namespace BL.Interfaces
{
    public interface IService<T>
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetSingleAsync(string id);

        Task<string> AddAsync(T objectToAdd);

        Task<bool> UpdateAsync(T objectToUpdate);

        Task<bool> DeleteAsync(string id);
    }
}
