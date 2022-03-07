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
    public class PlaylistService : IPlaylistService
    {
        IPlaylistRepository playlistRepository = new PlaylistRepository();

        public async Task CreateAsync(Playlist playlist)
        {
            await playlistRepository.CreateAsync(playlist);
        }

        public async Task DeleteAsync(int id)
        {
            await playlistRepository.DeleteAsync(id);
        }

        public async Task<IList<Playlist>> GetAllAsync(int size, int page)
        {
            var m = await playlistRepository.GetAllAsync();
            return m.Skip(size * (page - 1)).Take(size).ToList();
        }

        public Task<Playlist> GetAsync(int id)
        {
            return playlistRepository.GetAsync(id);
        }

        public Task<Playlist> UpdateAsync(Playlist playlist)
        {
            return playlistRepository.UpdateAsync(playlist);
        }
    }
}
