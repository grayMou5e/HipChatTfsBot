using HipChat.TfsBot.DataAccess.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace hiptfsbot.Controllers
{
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
        [HttpPost]
        [Route(Name = "CreateRoom")]
        public async Task<IHttpActionResult> CreateRoom([FromBody]Room room)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            if (!IsRoomValid(room)) { return BadRequest(); }

            var roomClient = new RoomClient("");
            //Insert!
            //var result = roomClient.Insert();
            return Ok();
        }

        private static bool IsRoomValid(Room room)
        {
            if (room == null || string.IsNullOrEmpty(room.AuthToken) || room.RoomId == 0 || (!string.IsNullOrWhiteSpace(room.Secret) && room.Secret.Length < 40))
            {
                return false;
            }

            return true;
        }
    }

    public class Room
    {
        public int RoomId { get; set; }
        public string AuthToken { get; set; }
        public string Secret { get; set; }
    }
}
