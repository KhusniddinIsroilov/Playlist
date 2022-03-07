using playlist.Data.IRepository;
using playlist.Models;
using playlist.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist.Data.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        SqlConnection con = new SqlConnection(Constants.CONNECTION_STRING);
        public async Task CreateAsync(Playlist playlist)
        {
            string q = $"INSERT INTO playlists(name, createdDate) VALUES('{playlist.Name}', '{playlist.CreatedDate}')";
            await con.OpenAsync();
            SqlCommand command = new SqlCommand(q, con);
            await command.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task DeleteAsync(int id)
        {
            SqlCommand delete = new SqlCommand($"delete playlists where id = {id}", con);
            await con.OpenAsync();
            await delete.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IList<Playlist>> GetAllAsync()
        {
            string q = "select * from playlists";
            SqlCommand com = new SqlCommand(q, con);
            await con.OpenAsync();
            SqlDataReader reader = await com.ExecuteReaderAsync();
            IList<Playlist> playlists = new List<Playlist>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    playlists.Add
                    (
                        new Playlist
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            CreatedDate = reader.GetString(2)
                        }
                    );
                }
                return playlists;
            }
            else
            {
                return null;
            }
        }

        public async Task<Playlist> GetAsync(int id)
        {
            string q = $"select * from playlists where id ={id}";
            SqlCommand com = new SqlCommand(q, con);
            await con.OpenAsync();
            SqlDataReader reader = await com.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                Playlist playlist = new Playlist
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    CreatedDate = reader.GetString(2),
                };
                return playlist;
            }
            else return null;

        }

        public async Task<Playlist> UpdateAsync(Playlist playlist)
        {
            string q = $"update playlists set name = '{playlist.Name}', createdDate = '{playlist.CreatedDate}' where id = {playlist.Id} ";
            SqlCommand com = new SqlCommand(q, con);

            await con.OpenAsync();
            await com.ExecuteNonQueryAsync();
            await con.CloseAsync();

            return playlist;
        }
    }
}
