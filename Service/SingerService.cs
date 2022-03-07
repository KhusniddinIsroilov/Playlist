using playlist.Data.IRepository;
using playlist.Data.Repository;
using playlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Service
{
    public class SingerService : ISingerService
    {
        ISingerRepository singerRepository = new SingerRepository();
        public async Task CreateAsync(Singer singer)
        {
            await singerRepository.CreateAsync(singer);
        }

        public async Task DeleteAsync(int id)
        {
            await singerRepository.DeleteAsync(id);
        }

        public async Task<IList<Singer>> GetAllAsync(int size, int page)
        {
           var n = await singerRepository.GetAllAsync();
           return n.Skip(size * (page - 1)).Take(size).ToList();
        }

        public async Task<Singer> GetAsync(int id)
        {
            return await singerRepository.GetAsync(id);
        }

        public async Task<Singer> UpdateAsync(Singer singer)
        {
            return await singerRepository.UpdateAsync(singer);
        }
    }
}
