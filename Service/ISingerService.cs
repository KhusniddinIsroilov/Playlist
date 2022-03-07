using playlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Service
{
    public interface ISingerService
    {
        Task<IList<Singer>> GetAllAsync(int size, int page);
        Task<Singer> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<Singer> UpdateAsync(Singer singer);
        Task CreateAsync(Singer singer);
    }
}
