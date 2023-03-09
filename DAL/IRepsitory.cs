using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRepsitory<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetSingleAsync(string id);
        Task<string> AddAsync(T objectToAdd);
        Task<bool> UpdatAsync(T objectToUpdate);
        Task<bool> DeleteAsync(string id);
    }
}
