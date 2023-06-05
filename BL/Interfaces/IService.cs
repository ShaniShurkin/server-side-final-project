namespace BL.Interfaces
{
    public interface IService<T>
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetSingleAsync(int code);

        Task<int> AddAsync(T objectToAdd);

        Task<bool> UpdateAsync(int code, T objectToUpdate);

        Task<bool> DeleteAsync(int code);
    }
}
