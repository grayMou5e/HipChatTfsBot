using HipChat.TfsBot.Domain.Entities;
using HipChat.TfsBot.Domain.Extensions;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace HipChat.TfsBot.DataAccess.Clients
{
    public class RoomClient
    {
        private string _connectionString;

        public RoomClient(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) { throw new ArgumentException(); }

            _connectionString = connectionString;
        }

        public async Task InsertAsync(Room room)
        {
            using (SqlConnection openCon = new SqlConnection(_connectionString))
            {
                var query = $"INSERT INTO Room(RoomId, AuthToken, Secret) VALUES({room.Id}, {room.AuthToken}, {room.Secret.Sha512()})";

                using(SqlCommand com = new SqlCommand(query))
                {
                    com.Connection = openCon;
                    openCon.Open();

                    await com.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
