using System;
using HipChat.TfsBot.Domain.ChatOptions;
using HipChat.TfsBot.Domain.DTO;
using HipChat.TfsBot.Domain.Entities;
using HipChat.TfsBot.Domain.Handlers;
using HipChat.TfsBot.Domain.TfsMessageBuilders;
using System.Threading.Tasks;
using System.Web.Http;
using HipChat.TfsBot.DataAccess.Clients;
using HipChat.TfsBot.Domain.Extensions;

namespace hiptfsbot.Controllers
{
    [RoutePrefix("api/Tfs")]
    public class TfsController : ApiController
    {
        [HttpPost]
        [Route("pullRequest", Name = "PullRequest")]
        public async Task<IHttpActionResult> PullRequest([FromUri]Guid id, [FromUri]string secret, [FromBody]PullRequest pullRequest)
        {
            var message = HipChatMessage.Create(Color.purple, pullRequest.detailedMessage.html, true, MessageFormat.html);

            return await SendStandartRequest(id, secret, message)
                            .ConfigureAwait(false);
        }

        [HttpPost]
        [Route("pullRequestUpdated", Name = "PullRequestUpdated")]
        public async Task<IHttpActionResult> PullRequestUpdated([FromUri]Guid id, [FromUri]string secret, [FromBody]PullRequest pullRequest)
        {
            var message = HipChatMessage.Create(new PullRequestUpdateMessageBuilder(pullRequest.detailedMessage.html));

            return await SendStandartRequest(id, secret, message)
                            .ConfigureAwait(false);

        }

        private async Task<IHttpActionResult> SendStandartRequest(Guid id, string secret, HipChatMessage message)
        {
            try
            {
                var roomClient = new RoomClient(@"Data Source=localhost;Initial Catalog=HipChat_tfsBot;Integrated Security=True;MultipleActiveResultSets=True");
                var room = await roomClient.GetRoomByIdAsync(id);

                if (room == null) { return BadRequest("Room not found"); }
                if (!string.Equals(room.Secret, secret.Sha512(), StringComparison.CurrentCultureIgnoreCase)) { return BadRequest("Invalid room setup"); }

                await message.SendAsync(new RequestHandler($@"https://vp-wolfpack.hipchat.com/v2/room/{room.RoomId}/notification?auth_token={room.AuthToken}"))
                    .ConfigureAwait(false);
                return Ok();
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
