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
    public class SingerRepository : ISingerRepository
    {
        SqlConnection con = new SqlConnection(Constants.CONNECTION_STRING);
        public async Task CreateAsync(Singer singer)
        {
            string q = $"INSERT INTO singers(fullname, createdDate) VALUES('{singer.FullName}', '{singer.CreatedDate}')";
            await con.OpenAsync();
            SqlCommand command = new SqlCommand(q, con);
            await command.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task DeleteAsync(int id)
        {
            SqlCommand delete = new SqlCommand($"delete singers where id = {id}", con);
            await con.OpenAsync();
            await delete.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task<IList<Singer>> GetAllAsync()
        {
            string q = "select * from singers";
            SqlCommand com = new SqlCommand(q, con);
            await con.OpenAsync();
            SqlDataReader reader = await com.ExecuteReaderAsync();
            IList<Singer> singers = new List<Singer>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    singers.Add
                    (
                        new Singer
                        {
                            Id = reader.GetInt32(0),
                            FullName = reader.GetString(1),
                            CreatedDate = reader.GetString(2)
                        }
                    );
                }
                return singers;
            }
            else
            {
                return null;
            }
        }

        public async Task<Singer> GetAsync(int id)
        {
            string q = $"select * from singers where id ={id}";
            SqlCommand com = new SqlCommand(q, con);
            await con.OpenAsync();
            SqlDataReader reader = await com.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                Singer singer = new Singer
                {
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    CreatedDate = reader.GetString(2),
                };
                return singer;
            }
            else return null;

        }

        public async Task<Singer> UpdateAsync(Singer singer)
        {
            string q = $"update singers set  fullname = '{singer.FullName}', createdDate = '{singer.CreatedDate}' where id = {singer.Id} ";
            SqlCommand com = new SqlCommand(q, con);

            await con.OpenAsync();
            await com.ExecuteNonQueryAsync();
            await con.CloseAsync();

            return singer;
        }
    }  
}
