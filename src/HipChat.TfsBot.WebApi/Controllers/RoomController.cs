using System;
using System.Threading.Tasks;
using System.Web.Http;
using HipChat.TfsBot.DataAccess.Clients;
using HipChat.TfsBot.Domain.ConfigManagement;
using HipChat.TfsBot.Domain.Entities;

namespace HipChat.TfsBot.WebApi.Controllers
{
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
        [HttpPost]
        [Route("", Name = "CreateRoom")]
        public async Task<IHttpActionResult> CreateRoom([FromBody] RoomDto room)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            if (!IsRoomValid(room)) { return BadRequest(); }

            var roomClient = new RoomClient(ConfigManagement.SqlConnectionString);

            var roomEntity = Room.Create(Guid.NewGuid(), room.RoomId, room.AuthToken, room.Secret);

            await roomClient.InsertAsync(roomEntity);

            return Ok(roomEntity.Id);
        }

        private static bool IsRoomValid(RoomDto room)
        {
            return !string.IsNullOrEmpty(room?.AuthToken) || room?.RoomId != 0 || (string.IsNullOrWhiteSpace(room.Secret) || room.Secret.Length >= 40);
        }
    }

    public class RoomDto
    {
        public int RoomId { get; set; }
        public string AuthToken { get; set; }
        public string Secret { get; set; }
    }
}