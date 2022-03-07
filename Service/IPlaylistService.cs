using playlist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Service
{
    public interface IPlaylistService
    {
        Task<IList<Playlist>> GetAllAsync(int size, int page);
        Task<Playlist> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<Playlist> UpdateAsync(Playlist playlist);
        Task CreateAsync(Playlist playlist);
    }
}
