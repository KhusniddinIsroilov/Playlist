using playlist.Data.IRepository;
using playlist.Data.Repository;
using playlist.Models;
using playlist.Service;
using System;
using System.Threading.Tasks;

namespace playlist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISingerService repo = new SingerService();
            IMusicService musicService = new MusicService();
            IPlaylistService _playList = new PlaylistService();

            Singer singer = new Singer()
            {
                Id = 1,
                FullName = "Sohib",
                CreatedDate = "52454"
            };
            //await repo.CreateAsync(singer);

            //Playlist playlist = new Playlist()
            //{
            //    Name = "Daxshat",
            //    CreatedDate = "4684321"
            //};
            //await _playList.CreateAsync(playlist);

            //Music music = new Music()
            //{
            //    Title = "new track",
            //    Description = "juda ajoyib",
            //    SingerID = 1,
            //    PlaylistID = 1,
            //    Length = 15,
            //    CreatedDate = "555454"
            //};

            //  await repo.CreateAsync(singer);

            //await repo.DeleteAsync(2);

            await repo.UpdateAsync(singer);

            var musics = await repo.GetAllAsync(10, 1);
            foreach (var musicss in musics)
            {
                Console.WriteLine(musicss.Id + " - " + musicss.FullName);
            }

            //var m = await musicService.GetAsync(1);
            //Console.WriteLine(m.Singer);

        }
    }
}
