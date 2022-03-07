using playlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Data.IRepository
{
    public interface ISingerRepository
    {
        Task<IList<Singer>> GetAllAsync();
        Task<Singer> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<Singer> UpdateAsync(Singer singer);
        Task CreateAsync(Singer singer);
    }
}
