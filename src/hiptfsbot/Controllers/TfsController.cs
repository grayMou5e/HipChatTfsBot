using HipChat.TfsBot.Domain.ChatOptions;
using HipChat.TfsBot.Domain.DTO;
using HipChat.TfsBot.Domain.Entities;
using HipChat.TfsBot.Domain.Handlers;
using HipChat.TfsBot.Domain.TfsMessageBuilders;
using System.Threading.Tasks;
using System.Web.Http;

namespace hiptfsbot.Controllers
{
    [RoutePrefix("api/Tfs")]
    public class TfsController : ApiController
    {
        [HttpPost]
        [Route("pullRequest", Name = "PullRequest")]
        public async Task<IHttpActionResult> PullRequest([FromUri]int id, [FromBody]PullRequest pullRequest)
        {
            var message = HipChatMessage.Create(Color.purple, pullRequest.detailedMessage.html, true, MessageFormat.html);

            return await SendStandartRequest(message)
                            .ConfigureAwait(false);
        }

        [HttpPost]
        [Route("pullRequestUpdated", Name = "PullRequestUpdated")]
        public async Task<IHttpActionResult> PullRequestUpdated([FromUri]int id, [FromBody]PullRequest pullRequest)
        {
            var message = HipChatMessage.Create(new PullRequestUpdateMessageBuilder(pullRequest.detailedMessage.html));

            return await SendStandartRequest(message)
                            .ConfigureAwait(false);

        }

        private async Task<IHttpActionResult> SendStandartRequest(HipChatMessage message)
        {
            try
            {
                await message.SendAsync(new RequestHandler("https://vp-wolfpack.hipchat.com/v2/room/3580924/notification?auth_token=jejjmkh5qysDkb9cCPn4q4UurMWDxhOlj9Di9WQ2"))
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
