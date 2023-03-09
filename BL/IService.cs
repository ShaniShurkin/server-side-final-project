using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
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
