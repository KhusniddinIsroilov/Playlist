using playlist.Data.IRepository;
using playlist.Models;
using playlist.Service;
using playlist.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Data.Repository
{
    public class MusicRepository : IMusicRepository
    {
        SqlConnection con = new SqlConnection(Constants.CONNECTION_STRING);
        public async Task CreateAsync(Music music)
        {
            string q = $"INSERT INTO musics(title, description, singerId, length, playlistId, createdDate) VALUES('{music.Title}', '{music.Description}', {music.SingerID}, {music.Length}, {music.PlaylistID}, '{music.CreatedDate}')";
            await con.OpenAsync();
            SqlCommand command = new SqlCommand(q, con);
            await command.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task DeleteAsync(int id)
        {
            SqlCommand delete = new SqlCommand($"delete musics where id = {id}", con);
            await con.OpenAsync();
            await delete.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IList<MusicView>> GetAllAsync()
        {
            string q = "SELECT musics.id, musics.title, musics.description, singers.fullname, musics.length, playlists.name, musics.createdDate FROM musics INNER JOIN playlists ON musics.playlistId = musics.id INNER JOIN singers ON musics.singerId = singers.id; ";
            SqlCommand com = new SqlCommand(q, con);
            await con.OpenAsync();
            SqlDataReader reader = await com.ExecuteReaderAsync();
            IList<MusicView> musics = new List<MusicView>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    musics.Add
                    (
                        new MusicView
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Singer = reader.GetString(3),
                            Length = reader.GetInt32(4),
                            Playlist = reader.GetString(5),
                            CreatedDate = reader.GetString(6)
                        }
                    );
                }
                return musics;
            }
            else
            {
                return null;
            }
        }

        public async Task<MusicView> GetAsync(int id)
        {
            string q = $"SELECT musics.id, musics.title, musics.description, singers.fullname, musics.length, playlists.name, musics.createdDate FROM musics INNER JOIN playlists ON musics.playlistId = musics.id INNER JOIN singers ON musics.singerId = singers.id where musics.id = {id} ";
            SqlCommand com = new SqlCommand(q, con);
            await con.OpenAsync();
            SqlDataReader reader = await com.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                MusicView music = new MusicView
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Description = reader.GetString(2),
                    Singer = reader.GetString(3),
                    Length = reader.GetInt32(4),
                    Playlist = reader.GetString(5),
                    CreatedDate = reader.GetString(6)
                };
                return music;
            }
            else return null;

        }

        public async Task<Music> UpdateAsync(Music music)
        {
            string q = $"update musics set title = '{music.Title}', description = '{music.Description}', singerId = {music.SingerID}, length = {music.Length}, playlistId = {music.PlaylistID}, createdDate = '{music.CreatedDate}' where id = {music.Id} ";
            SqlCommand com = new SqlCommand(q, con);

            await con.OpenAsync();
            await com.ExecuteNonQueryAsync();
            await con.CloseAsync();

            return music;
        }
    }
}
