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
        private readonly string _connectionString;

        public RoomClient(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) { throw new ArgumentException(); }

            _connectionString = connectionString;
        }

        public async Task InsertAsync(Room room)
        {
            using (var openCon = new SqlConnection(_connectionString))
            {
                var query = $"INSERT INTO Room(Id,RoomId, AuthToken, Secret) VALUES('{room.Id}', {room.RoomId},'{room.AuthToken}', '{room.Secret}')";

                using (var com = new SqlCommand(query))
                {
                    com.Connection = openCon;
                    openCon.Open();

                    await com.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Room> GetRoomByIdAsync(Guid id)
        {
            using (var openCon = new SqlConnection(_connectionString))
            {
                var query = $"SELECT [Id],[RoomId],[AuthToken],[Secret] FROM [dbo].[Room] WHERE Id='{id}'";

                using (var com = new SqlCommand(query))
                {
                    com.Connection = openCon;
                    openCon.Open();

                    var result = await com.ExecuteReaderAsync();

                    if (!result.HasRows) return null;

                    result.Read();
                    return new Room
                    {
                        Id = (Guid)result.GetValue(0),
                        RoomId = (int)result.GetValue(1),
                        AuthToken = (string)result.GetValue(2),
                        Secret = (string)result.GetValue(3),
                    };
                }
            }
        }
    }
}
