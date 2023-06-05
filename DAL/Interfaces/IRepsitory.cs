namespace DAL.Interfaces
{
    public interface IRepsitory<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetSingleAsync(int code);
        Task<int> AddAsync(T objectToAdd);
        Task<bool> UpdatAsync(int code, T objectToUpdate);
        Task<bool> DeleteAsync(int code);
    }
}
