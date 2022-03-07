using playlist.Models;
using playlist.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Service
{
    public interface IMusicService
    {
        Task<IList<MusicView>> GetAllAsync(int size, int index);
        Task<MusicView> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<Music> UpdateAsync(Music music);
        Task CreateAsync(Music music);
    }
}
