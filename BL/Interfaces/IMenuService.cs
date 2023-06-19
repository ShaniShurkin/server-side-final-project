using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IMenuService
    {
        Task<bool> UpdateMenu(int code, string menu);
        Task<string> CreateMenu(List<FoodDTO> foods, int code);
    }
}
