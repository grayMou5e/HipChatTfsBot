using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Http;
using HipChat.TfsBot.DataAccess.Clients;
using HipChat.TfsBot.Domain.Extensions;

namespace hiptfsbot.Controllers
{
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
        [HttpPost]
        [Route("", Name = "CreateRoom")]
        public async Task<IHttpActionResult> CreateRoom([FromBody] Room room)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            if (!IsRoomValid(room)) { return BadRequest(); }

            var roomClient = new RoomClient(@"Data Source=localhost;Initial Catalog=HipChat_tfsBot;Integrated Security=True;MultipleActiveResultSets=True");
            //Insert

            var roomEntity = new HipChat.TfsBot.Domain.Entities.Room
            {
                Id = Guid.NewGuid(),
                AuthToken = room.AuthToken,
                RoomId = room.RoomId,
                Secret = room.Secret.Sha512()
            };

            await roomClient.InsertAsync(roomEntity);

            return Ok(roomEntity.Id);
        }

        private static bool IsRoomValid(Room room)
        {
            return !string.IsNullOrEmpty(room?.AuthToken) || room.RoomId != 0 || (string.IsNullOrWhiteSpace(room.Secret) || room.Secret.Length >= 40);
        }
    }

    public class Room
    {
        public int RoomId { get; set; }
        public string AuthToken { get; set; }
        public string Secret { get; set; }
    }
}