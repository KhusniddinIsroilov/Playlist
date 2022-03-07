using playlist.Data.IRepository;
using playlist.Data.Repository;
using playlist.Models;
using playlist.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Service
{
    public class MusicService : IMusicService
    {
        IPlaylistRepository playlistRepository = new PlaylistRepository();
        ISingerRepository singerRepository = new SingerRepository();
        IMusicRepository musicRepository = new MusicRepository();

        public async Task CreateAsync(Music music)
        {
            await musicRepository.CreateAsync(music);
        }

        public async Task DeleteAsync(int id)
        {
            await musicRepository.DeleteAsync(id);
        }

        public async Task<IList<MusicView>> GetAllAsync(int size, int index)
        {
                //var playlist = playlistRepository.GetAllAsync().Result;
                //var singer = await singerRepository.GetAllAsync();
                //var music = await musicRepository.GetAllAsync();
                //var MethodSyntax = music.Join(singer, m => m.SingerID,
                //    s => s.Id,
                //    (m, s) => new {
                //        Id = m.Id,
                //        Title = m.Title,
                //        Description = m.Description,
                //        Singer = s.FullName,
                //        Length = m.Length,
                //        PlaylistId = m.Id,
                //        CreatedDate = m.CreatedDate,
                //    }).ToList();

                //var MethodSyntax1 = MethodSyntax.Join(playlist, m => m.PlaylistId,
                //    p => p.Id,
                //    (m, p) => new {
                //        Id = m.Id,
                //        Title = m.Title,
                //        Description = m.Description,
                //        Singer = m.Singer,
                //        Length = m.Length,
                //        PlaylistId = p.Name,
                //        CreatedDate = m.CreatedDate,
                //    }).ToList();
                //return MethodSyntax1;

            var music = await musicRepository.GetAllAsync();
            return music.Skip(size * (index - 1)).Take(size).ToList();
        }

        public async Task<MusicView> GetAsync(int id)
        {
            /*var playlist = playlistRepository.GetAllAsync().Result;
            var singer = await singerRepository.GetAllAsync();
            var music = await musicRepository.GetAllAsync();
            var MethodSyntax = music.Join(singer, m => m.SingerID,
                s => s.Id,
                (m, s) => new {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Singer = s.FullName,
                    Length = m.Length,
                    PlaylistId = m.Id,
                    CreatedDate = m.CreatedDate,
                }).ToList();

            var MethodSyntax1 = MethodSyntax.Join(playlist, m => m.PlaylistId,
                p => p.Id,
                (m, p) => new {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Singer = m.Singer,
                    Length = m.Length,
                    PlaylistId = p.Name,
                    CreatedDate = m.CreatedDate,
                }).ToList();*/

            return await musicRepository.GetAsync(id);
        }

        public async Task<Music> UpdateAsync(Music music)
        {
            return await musicRepository.UpdateAsync(music);
        }
    }
}
