using HipChat.TfsBot.Domain.Entities;
using System;
using System.Data.SqlClient;
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

        public async Task<bool> InsertAsync(Room room)
        {
            using (SqlConnection openCon = new SqlConnection(_connectionString))
            {
                var query = "";

                using(SqlCommand com = new SqlCommand(query))
                {
                    com.Connection = openCon;
                    openCon.Open();

                    await com.ExecuteNonQueryAsync();
                }
            }

            return true;
        }
    }
}
